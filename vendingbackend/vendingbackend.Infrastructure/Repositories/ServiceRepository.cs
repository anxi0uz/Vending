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
    public class ServiceRepository : IServiceRepository
    {
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext _context { get; }

        public async Task<List<ServiceResponse>> GetServicesAsync()
        {
            return await _context.Services
                .AsNoTracking()
                .Select(s => new ServiceResponse(s.Id, s.ApparatusId, s.Date, s.Description, s.Problems, s.UserId))
                .ToListAsync();
        }
        public async Task<int> CreateServiceAsync(ServiceRequest request)
        {
            var model = new Service
            {
                ApparatusId = request.apparatusid,
                Date = request.Date,
                Description = request.description,
                Problems = request.problems,
                UserId = request.UserId,
            };
            await _context.Services.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<int> UpdateServiceAsync(int id, ServiceRequest request)
        {
            await _context.Services
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.ApparatusId, request.apparatusid)
                .SetProperty(s => s.Problems, request.problems)
                .SetProperty(s => s.UserId, request.UserId)
                .SetProperty(s => s.Description, request.description)
                .SetProperty(s => s.Date, request.Date));
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<int> DeleteServiceAsync(int id)
        {
            await _context.Services.Where(s => s.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
