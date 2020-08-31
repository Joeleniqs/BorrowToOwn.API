using System;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BorrowToOwn.API.Controllers
{
    [ApiController]
    [Route("/api/Brands")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
        }
        // GET: /<controller>/
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cats = await _brandService.GetBrandsAsync();

            return Ok(cats);
        }

        [HttpGet("{id:int}", Name = "GetBrand")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var cat = await _brandService.GetBrandAsync(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] BrandRequestObject brandRequestObject)
        {
            var res = await _brandService.AddBrandAsync(brandRequestObject);

            if (res == null) return BadRequest("Unable to create Brand at this time.");

            return CreatedAtRoute("GetBrand", new { id = res.Id }, res);

        }
    }
}
