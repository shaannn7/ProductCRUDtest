using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManager.Dbcontext;
using ProductManager.Dto;
using ProductManager.Entity;

namespace ProductManager.Services.ProductService
{
    public class ProductRepostory : IProducts
    {
        private readonly DbContextClass _dbContextClass;
        private readonly IMapper _mapper;

        public ProductRepostory(DbContextClass dbContextClass, IMapper mapper)
        {
            _dbContextClass = dbContextClass;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetallProducts()
        {
            var prd = await _dbContextClass.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(prd);
        }

        public async Task<ProductDto> GetbyId(int id)
        {
            var prd = await _dbContextClass.Products.FirstOrDefaultAsync(i=>i.productid == id);
            return _mapper.Map<ProductDto>(prd);
        }
        public async Task<List<ProductDto>> GetbyName(string pname)
        {
            var prd = await _dbContextClass.Products.Where(i=>i.productname.StartsWith(pname)).ToListAsync();
            if(prd != null)
            {
                var data = prd.Select(i => new ProductDto
                {
                    productid = i.productid,
                    productname = i.productname,
                    productprice = i.productprice,
                    categoryid = i.categoryid,
                }).ToList();
                return data;
            }
            return new List<ProductDto>();
        }
        public async Task<List<ProductDto>> GetbyCategory(string pcatgry)
        {
            var prd = await _dbContextClass.Products.Where(i => i.category.categoryname.StartsWith(pcatgry)).ToListAsync();
            if (prd != null)
            {
                var data = prd.Select(i => new ProductDto
                {
                    productid = i.productid,
                    productname = i.productname,
                    productprice = i.productprice,
                    categoryid = i.categoryid,
                }).ToList();
                return data;
            }
            return new List<ProductDto>();
        }
        public async Task AddProduct(ProductDto product)
        {
           var prd = _mapper.Map<Product>(product);
            _dbContextClass.Add(prd);
            await _dbContextClass.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, ProductDto product)
        {
            var prd = await _dbContextClass.Products.FirstOrDefaultAsync(i => i.productid == id);
            prd.productname = product.productname;
            prd.productprice = product.productprice;
            prd.categoryid = product.categoryid;
            await _dbContextClass.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var prd = await _dbContextClass.Products.FirstOrDefaultAsync(i=>i.productid == id);
            _dbContextClass.Products.Remove(prd);
            await _dbContextClass.SaveChangesAsync();
        }
    }
}
