using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BorrowToOwn.Data.Models;
using BorrowToOwn.Data.Repository.Contracts;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static BorrowToOwn.Data.Common.AppEnum;
using BorrowToOwn.Services.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BorrowToOwn.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly IPaymentPlanService _paymentPlanService;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger, IPaymentPlanService paymentPlanService)
        {
            _productRepo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _paymentPlanService = paymentPlanService ?? throw new ArgumentNullException(nameof(paymentPlanService));
        }

        public async Task<ProductResponseObject> AddProductAsync(ProductRequestObject product, HttpClient bucketClient)
        {
            //Get Associated Payment plans
            var productPlans = new List<ProductPaymentPlan>();
            foreach (int id in product.AssociatedPaymentPlans)
            {
                var plan = await _paymentPlanService.GetPaymentPlanAsync(id);
                if (plan == null) throw new Exception("No Active Associated Plan ");
                productPlans.Add(new ProductPaymentPlan { PaymentPlanName = plan.PlanName, ProductName = product.Name, PaymentPlanId = plan.Id });
            }

            //add cover image
            S3AddFileResponse coverImageObj = (await AddImageToS3Bucket(product.CoverImage, bucketClient))[0];
            var productImages = new List<ProductImage>()
            {
                new ProductImage{
                    ImageUrl = coverImageObj?.ActualObjectUrl ?? "cover",
                    IsCoverImage = true,
                }
            };

            //add other images
            foreach (var image in product.AlternateProductImages)
            {
                S3AddFileResponse imageObj = (await AddImageToS3Bucket(image, bucketClient))[0];
                productImages.Add(new ProductImage { ImageUrl = imageObj?.ActualObjectUrl ?? "Alt --", IsCoverImage = false });
            }

            //add available colours
            List<string> availableColours = new List<string>();
            foreach (int c in product.AvailableProductColours)
            {
                var colour = (ProductColour)c;
                availableColours.Add(colour.ToString());
            }

            //map reqObj to product entity
            var productEntity = _mapper.Map<Product>(product);
            productEntity.ProductImages = productImages;
            productEntity.AllowedPaymentPlans = productPlans;
            productEntity.TimeStampCreated = DateTimeOffset.Now;
            productEntity.AvailableColours = availableColours;

            var newProduct = await _productRepo.AddProductAsync(productEntity);
            if (newProduct == null) return null;
            var result = _mapper.Map<ProductResponseObject>(newProduct);
            return result;
        }



        public async Task<ProductResponseObject> GetProductAsync(long id)
        {
            var product = await _productRepo.GetProductAsync(id);
            if (product == null) return null;
            return _mapper.Map<ProductResponseObject>(product);
        }

        public async Task<PagedList<Product>> GetProductsAsync(Pagination pagination)
        {
            if (pagination == null)
            {
                throw new ArgumentNullException(nameof(pagination));
            }

            var collection = await _productRepo.GetProductsAsync();

            if (pagination.CategoryId > 0)
            {
                collection = collection.Where(a => a.CategoryId == pagination.CategoryId);
            }

            if (pagination.SubCategoryId > 0)
            {
                collection = collection.Where(a => a.SubCategoryId == pagination.SubCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(pagination.SearchQuery))
            {

                var searchQuery = pagination.SearchQuery.Trim();
                collection = collection
                  .Where(product =>product.SearchVector.Matches(searchQuery));
            }
            var products = PagedList<Product>.Create(collection,
           pagination.PageNumber,
           pagination.PageSize);

            return products;
        }

        public void UpdateProduct()
        {
            //for extensibility
        }


        private async Task<T> JsonDeserializer<T>(string toConvert)
        {
            var resp = await Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<T>(toConvert);
            });

            if (resp == null) throw new ArgumentNullException("Unable To Deserialize Response!");

            return resp;
        }

        private async Task<byte[]> ConvertToByteArray(IFormFile coverImage)
        {
            if (coverImage.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await coverImage.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    //string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                    return fileBytes;
                }
            }
            return null;
        }

        private async Task<List<S3AddFileResponse>> AddImageToS3Bucket(IFormFile image, HttpClient bucketClient)
        {
            //convert iformfile to byte array
            byte[] imagefile_bytes = await ConvertToByteArray(image);
            if (imagefile_bytes == null) throw new Exception("Unable to stream cover image file");

            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new StringContent("1"), "fileType");
            form.Add(new ByteArrayContent(imagefile_bytes), "formFiles", image.FileName);

            var response = await bucketClient.PostAsync("/api/file/borrow-s3-bucket", form);
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(respStr)) return null;

            var respObj = await JsonDeserializer<List<S3AddFileResponse>>(respStr);
            return respObj;
        }


    }
}
