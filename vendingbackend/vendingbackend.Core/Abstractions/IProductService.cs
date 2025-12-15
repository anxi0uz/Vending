using vendingbackend.Core.DTOs;

namespace vendingbackend.Application.Services
{
    public interface IProductService
    {
        Task<int> CreateProductAsync(ProductRequest request);
        Task<int> DeleteProductAsync(int id);
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<int> UpdateProductAsync(int id, ProductRequest request);
    }
}