using System;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BorrowToOwn.API.Controllers
{
    [ApiController]
    [Route("/api/Categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

        }
        // GET: /<controller>/
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cats = await _categoryService.GetCategoriesAsync();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id,bool includeSubCategory = false)
        {
            var cat = await _categoryService.GetCategoryAsync( id,includeSubCategory);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpPost("")]
        public async  Task<IActionResult> Post([FromBody] CategoryRequestObject categoryRequestObject)
        {
            var res = await _categoryService.AddCategoryAsync(categoryRequestObject);
            if (res == null) return BadRequest("Unable to create category at this time.");
            return Ok(res);
        }

    }
}
