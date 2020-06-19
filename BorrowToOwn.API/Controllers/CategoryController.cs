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

        [HttpGet("{id:int}",Name ="GetCategory")]
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

            return CreatedAtRoute("GetCategory" , new { id = res.Id,includeSubCategory= true},res);

        }

        [HttpDelete("{id:int}/ToggleActive")]
        public async Task<IActionResult> ToggleCategoryActive(int id)
        {
            var check = await _categoryService.IsCategoryValidAsync(id);

            if (!check) return BadRequest("No Such Category");

            var res = await _categoryService.DeleteCategoryAsync(id);

            if (!res) return BadRequest("Unable to delete category at this time.");

            return NoContent();
        }
        [HttpPost("{id:int}/SubCategories")]
        public async Task<IActionResult> AddSubCategory(int id ,[FromBody] SubCategoryRequestObject subCategoryRequestObject)
        {
            var check = await _categoryService.IsCategoryValidAsync(id);

            if (!check) return BadRequest("No Such Category");

            var res = await _categoryService.AddSubCategoryAsync( id, subCategoryRequestObject);

            if (!res) return BadRequest("Unable to create sub - category at this time.");

            return CreatedAtRoute("GetCategory", new { id, includeSubCategory = true },subCategoryRequestObject);
        }
        [HttpDelete("{id:int}/SubCategories/{subCategoryId:int}/ToggleActive")]
        public async Task<IActionResult> ToggleSubCategoryActive(int id , int subCategoryId)
        {
            var check = await _categoryService.IsCategoryValidAsync(id,subCategoryId);

            if (!check) return BadRequest("No Such Category");

            var res = await _categoryService.DeleteSubCategoryAsync(id,subCategoryId);

            if (!res) return BadRequest("Unable to delete sub - category at this time.");

            return NoContent();
        }
    }
}
