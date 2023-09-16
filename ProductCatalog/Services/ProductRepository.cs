using Microsoft.EntityFrameworkCore;
using ProductCatalog.DB.Entities;
using ProductCatalog.DB;

namespace ProductCatalog.Services
{
public class ProductRepository
{
    private readonly ProductCatalogDbContext _dbContext;

    public ProductRepository(ProductCatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _dbContext.Products.AsNoTracking().ToListAsync();
    }

    public async Task<List<ProductType>> GetProductTypes()
    {
        return await _dbContext.ProductTypes.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ProductType?> GetProductTypeById(int id)
    {
        return await _dbContext.ProductTypes.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddProductType(ProductType productType)
    {
        _dbContext.ProductTypes.Add(productType);
        await _dbContext.SaveChangesAsync();
    }

public async Task UpdateProduct(Product product)
{
    // Check if the Product entity is already tracked
    var existingProduct = await _dbContext.Products.FindAsync(product.Id);
    if (existingProduct != null)
    {
        // Update the tracked entity with the values from the updated entity
        _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
        await _dbContext.SaveChangesAsync();
    }
}

    public async Task UpdateProductType(ProductType productType)
    {
        // Check if the Product entity is already tracked
        var existingProduct = await _dbContext.ProductTypes.FindAsync(productType.Id);
        if (existingProduct != null)
        {
            // Update the tracked entity with the values from the updated entity
            _dbContext.Entry(existingProduct).CurrentValues.SetValues(productType);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteProduct(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductType(ProductType productType)
    {
        _dbContext.ProductTypes.Remove(productType);
        await _dbContext.SaveChangesAsync();
    }
}
}
