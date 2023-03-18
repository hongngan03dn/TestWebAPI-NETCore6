using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebAPIByVSPurple.Models;
using TestWebAPIByVSPurple.Repositories;

namespace TestWebAPIByVSPurple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesRepoPatternController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoriesRepoPatternController(ICategoryRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories() 
        {
            try
            {
                return Ok(await _repo.GetAllCategoriesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            var cate = await _repo.GetCategoryAsync(id);
            return cate == null ? NotFound() : Ok(cate);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryModel model)
        {
            try
            {
                var newId = await _repo.AddCategoryAsync(model);
                var cate = await _repo.GetCategoryAsync(newId);
                return cate == null ? NotFound() : Ok(cate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryModel model)
        {
            await _repo.UpdateCategoryAsync(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _repo.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
