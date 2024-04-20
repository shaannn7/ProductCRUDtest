using Microsoft.AspNetCore.Mvc;
using ProductManager.Dto;
using ProductManager.Services.ProductService;

namespace ProductManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProducts _products;

        public ProductController(IConfiguration configuration, IProducts products)
        {
            _configuration = configuration;
            _products = products;
        }

        [HttpGet("Get All Products")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _products.GetallProducts();
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get BY ID = {id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var data = await _products.GetbyId(id);
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search by Product Name = {name}")]
        public async Task<IActionResult> searchbypname(string name)
        {
            try
            {
                var data = await _products.GetbyName(name);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search by Product Category = {catname}")]
        public async Task<IActionResult> searchbypcatg(string catname)
        {
            try
            {
                var data = await _products.GetbyCategory(catname);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add Prduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                await _products.AddProduct(productDto);
                return Ok("Product Added");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update Product")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                await _products.UpdateProduct(id, productDto);
                return Ok("Product Updated");
            }
            catch(Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete Product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _products.DeleteProduct(id);
                return Ok("Product Removed");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
