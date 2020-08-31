using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Communications.ResponseObject.DTO;
using BorrowToOwn.Services.Contracts;
using BorrowToOwn.Services.Helpers;
using Microsoft.AspNetCore.Mvc;
using static BorrowToOwn.Data.Common.AppEnum;

namespace BorrowToOwn.API.Controllers
{
    [ApiController]
    [Route("/api/Products")]
    public class ProductController:Controller
    {
        private readonly IProductService _productService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IHttpClientFactory httpClientFactory,IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpPost("")  ,
         DisableRequestSizeLimit,
         RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] ProductRequestObject productRequestObject)
        {
            return Ok();
            var bucketClient = _httpClientFactory.CreateClient("S3BucketClient");

            var res = await _productService.AddProductAsync(productRequestObject,bucketClient);

            if (res == null) return BadRequest("Unable to create Product at this time.");

            return CreatedAtRoute("GetProduct", new {res.Id}, res);
        }
        [HttpGet("{Id:int}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var product = await _productService.GetProductAsync(Id);

            if (product == null) return NotFound();

            return Ok(product);
        }
        [HttpGet(Name = "GetProducts")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ProductResponseObject>>> GetProducts(
          [FromQuery] Pagination pagination)
        {
            var productsFromService = await _productService.GetProductsAsync(pagination);
            var productsResponse = _mapper.Map<IEnumerable<ProductResponseObject>>(productsFromService);


            var previousPageLink = productsFromService.HasPrevious ?
              CreateAuthorsResourceUri(pagination,
              ResourceUriType.PreviousPage) : null;

            var nextPageLink = productsFromService.HasNext ?
                CreateAuthorsResourceUri(pagination,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = productsFromService.TotalCount,
                pageSize = productsFromService.PageSize,
                currentPage = productsFromService.CurrentPage,
                totalPages = productsFromService.TotalPages,
                previousPageLink,
                nextPageLink
            };
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(productsResponse);
        }

        private string CreateAuthorsResourceUri(
        Pagination pagination,
        ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetProducts",
                      new
                      {
                          pageNumber = pagination.PageNumber - 1,
                          pageSize = pagination.PageSize,
                          pagination.CategoryId,
                          pagination.SubCategoryId,
                          searchQuery = pagination.SearchQuery
                      });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors",
                      new
                      {
                          pageNumber = pagination.PageNumber + 1,
                          pageSize = pagination.PageSize,
                          pagination.CategoryId,
                          pagination.SubCategoryId,
                          searchQuery = pagination.SearchQuery
                      });

                default:
                    return Url.Link("GetAuthors",
                    new
                    {
                        pageNumber = pagination.PageNumber,
                        pageSize = pagination.PageSize,
                        pagination.CategoryId,
                        pagination.SubCategoryId,
                        searchQuery = pagination.SearchQuery
                    });
            }

        }
    }
}
