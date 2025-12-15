using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vendingbackend.Core.DTOs;
using vendingbackend.Infrastructure.Repositories;

namespace vendingbackend.Application.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository repository;

        public ServicesService(IServiceRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<ServiceResponse>> GetAllServicesAsync()
        {
            return await repository.GetServicesAsync();
        }
        public async Task<int> CreateServiceAsync(ServiceRequest request)
        {
            return await repository.CreateServiceAsync(request);
        }
        public async Task<int> UpdateServiceAsync(int id, ServiceRequest request)
        {
            return await repository.UpdateServiceAsync(id, request);
        }
        public async Task<int> DeleteServiceAsync(int id)
        {
            return await repository.DeleteServiceAsync(id);
        }
    }
}
