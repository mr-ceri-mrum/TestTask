using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestHardCode.Data;
using TestHardCode.Models;

namespace TestHardCode.Services;

public interface IProductService
{
    public Task<Product> CreatProduct(Product product);
    public Task<IQueryable<Product>> GetProductById(Guid guid);
    public Task<List<Product>> GetProductList();
    public Task<IEnumerable<Product>?> GetCategoryProductsById(int id);

}

public class ProductService : IProductService
{
    private readonly DataContext _dbContext;
    
    public ProductService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> CreatProduct(Product product)
    {
        try
        {
            var newProduct = new Product(product.NameProduct, product.Category, product.Price, product.StatusProduct);
            await _dbContext.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return newProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IQueryable<Product>> GetProductById(Guid guid)
    {
        try
        {
            var products = _dbContext
                .Set<Product>()
                .AsNoTracking();
            
            var product = await products.FirstOrDefaultAsync(x => x.Id == guid);
            
            return product is not null ? products : null!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Product>> GetProductList()
    {
        var products = await _dbContext
            .Set<Product>()
            .AsNoTracking()
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>?> GetCategoryProductsById(int id)
    {
        var products = await _dbContext
            .Set<Product>()
            .AsNoTracking()
            .ToListAsync() ?? null;

        if (products != null) 
            return products.Where(x => x.Category != null && x.Category.Id == id);
        
        return null;
    }
}