using vendingbackend.Core.DTOs;

namespace vendingbackend.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<int> CreateProductAsync(ProductRequest request);
        Task<int> DeleteProductAsync(int id);
        Task<List<ProductResponse>> GetProductsAsync();
        Task<int> UpdateProductAsync(int id, ProductRequest request);
    }
}