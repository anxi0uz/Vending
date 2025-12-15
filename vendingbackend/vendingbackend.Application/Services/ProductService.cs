using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vendingbackend.Core.DTOs;
using vendingbackend.Infrastructure.Repositories;

namespace vendingbackend.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }
        public async Task<int> CreateProductAsync(ProductRequest request)
        {
            return await _repository.CreateProductAsync(request);
        }
        public async Task<int> UpdateProductAsync(int id, ProductRequest request)
        {
            return await _repository.UpdateProductAsync(id, request);
        }
        public async Task<int> DeleteProductAsync(int id)
        {
            return await _repository.DeleteProductAsync(id);
        }
    }
}
