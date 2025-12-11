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
    public class SalesRepository : ISalesRepository
    {
        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext _context { get; }

        public async Task<List<SalesResponse>> GetSalesAsync()
        {
            return await _context.Sales
                .AsNoTracking()
                .Select(s => new SalesResponse(s.Id, s.ApparatusId, s.ProductId, s.Quantity, s.TotalPrice, s.SaleDate, s.PayType.ToString()))
                .ToListAsync();
        }

        public async Task<int> CreateSaleAsync(SalesRequest request)
        {
            var model = new Sales()
            {
                ApparatusId = request.apparatusid,
                Quantity = request.quantity,
                ProductId = request.productid,
                TotalPrice = request.totalprice,
                SaleDate = request.saledate,
                PayType = (PayType)request.PayType
            };
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> UpdateSaleAsync(int id, SalesRequest request)
        {
            await _context.Sales.Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.ProductId, request.productid)
                .SetProperty(s => s.ApparatusId, request.apparatusid)
                .SetProperty(s => s.PayType, (PayType)request.PayType)
                .SetProperty(s => s.Quantity, request.quantity)
                .SetProperty(s => s.SaleDate, request.saledate)
                .SetProperty(s => s.TotalPrice, request.totalprice));
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<int> DeleteSaleAsync(int id)
        {
            await _context.Sales.Where(s => s.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
