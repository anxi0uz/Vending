using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;
using vendingbackend.Infrastructure.DataAccess;

namespace vendingbackend.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AppDbContext _dbContext { get; }

        public async Task<List<ProductResponse>> GetProductsAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Select(s => new ProductResponse(s.Id, s.Name, s.Description, s.Price, s.Quantity, s.MinimalStock, s.AvgDailySales))
                .ToListAsync();
        }

        public async Task<int> CreateProductAsync(ProductRequest request)
        {
            var model = new Product()
            {
                Name = request.name,
                Description = request.description,
                Price = request.price,
                Quantity = request.quantity,
                MinimalStock = request.minimalstock,
                AvgDailySales = request.avgdailysales,
            };
            await _dbContext.Products.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> UpdateProductAsync(int id, ProductRequest request)
        {
            await _dbContext.Products.Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.Name, request.name)
                .SetProperty(s => s.Description, request.description)
                .SetProperty(s => s.Quantity, request.quantity)
                .SetProperty(s => s.Price, request.price)
                .SetProperty(s => s.AvgDailySales, request.avgdailysales)
                .SetProperty(s => s.MinimalStock, request.minimalstock));
            await _dbContext.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            await _dbContext.Products.Where(s => s.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
