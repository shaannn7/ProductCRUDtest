using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductManager.Dbcontext;
using ProductManager.Dto;
using ProductManager.Entity;
using ProductManager.Mapper;

namespace ProductManager.Services.CategoryService
{
    public class CategoryRepostory : ICategory
    {
        private readonly DbContextClass _dbContextClass;
        private readonly IMapper _mapper;
        public CategoryRepostory(DbContextClass dbContextClass , IMapper mapper)
        {
            _dbContextClass = dbContextClass;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategory()
        {
            var catg = await _dbContextClass.Categories.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(catg);
        }

        public async Task<CategoryDto> SearchCategorybyid(int id)
        {
            var catg = await _dbContextClass.Categories.FirstOrDefaultAsync(i => i.categoryid == id);
            return _mapper.Map<CategoryDto>(catg);
        }

        public async Task AddCategory(CategoryDto category)
        {
            var catg = _mapper.Map<Category>(category);
            _dbContextClass.Categories.Add(catg);
            await _dbContextClass.SaveChangesAsync();
        }

        public async Task UpdateCategory(int id, CategoryDto categoryDto)
        {
            var catg = await _dbContextClass.Categories.FirstOrDefaultAsync(i=>i.categoryid == id);
            catg.categoryname = categoryDto.CategoryName;
            await _dbContextClass.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var catg = await _dbContextClass.Categories.FirstOrDefaultAsync(i=>i.categoryid == id);
            _dbContextClass.Categories.Remove(catg);
            await _dbContextClass.SaveChangesAsync();
        }
    }
}
