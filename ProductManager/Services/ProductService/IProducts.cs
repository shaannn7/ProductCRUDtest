using ProductManager.Dto;
using ProductManager.Entity;

namespace ProductManager.Services.ProductService
{
    public interface IProducts
    {
        Task<List<ProductDto>> GetallProducts();
        Task<ProductDto> GetbyId(int id);
        Task<List<ProductDto>> GetbyName(string pname);
        Task<List<ProductDto>> GetbyCategory(string pcatgry);
        Task AddProduct(ProductDto product);
        Task UpdateProduct(int id, ProductDto product);
        Task DeleteProduct(int id);
    }
}
