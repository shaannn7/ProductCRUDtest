using Microsoft.AspNetCore.Mvc;
using ProductManager.Dto;
using ProductManager.Services.CategoryService;

namespace ProductManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _catg;
        private readonly IConfiguration _configuration;
        public CategoryController(ICategory catg, IConfiguration configuration)
        {
            _catg = catg;
            _configuration = configuration;
        }

        [HttpGet("Get All Category")]
        public async Task<IActionResult> GetAllCatg() 
        {
            try
            {
               var data = await _catg.GetAllCategory();
                return Ok(data);
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search Category by ID={id}")]
        public async Task<IActionResult> Search(int id)
        {
            try
            {
                var data = await _catg.SearchCategorybyid(id);
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add Category")]
        public async Task<IActionResult> AddCatg([FromBody] CategoryDto categoryDto)
        {
            try
            {
                await _catg.AddCategory(categoryDto);
                return Ok("Category Added");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update Category")]
        public async Task<IActionResult> UpdateCatg(int id , [FromBody] CategoryDto categoryDto)
        {
            try
            {
                await _catg.UpdateCategory(id, categoryDto);
                return Ok("Category Updated");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete Category")]
        public async Task<IActionResult> DeleteCatg(int id)
        {
            try
            {
                await _catg.DeleteCategory(id);
                return Ok("Category Removed");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
