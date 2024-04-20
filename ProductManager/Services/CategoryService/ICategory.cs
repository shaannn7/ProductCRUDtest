using ProductManager.Dto;
using ProductManager.Entity;

namespace ProductManager.Services.CategoryService
{
    public interface ICategory
    {
        Task<List<CategoryDto>> GetAllCategory();
        Task <CategoryDto> SearchCategorybyid(int id);
        Task AddCategory(CategoryDto category);
        Task UpdateCategory(int id, CategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}
