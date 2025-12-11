using vendingbackend.Core.DTOs;

namespace vendingbackend.Infrastructure.Repositories
{
    public interface IServiceRepository
    {
        Task<int> CreateServiceAsync(ServiceRequest request);
        Task<int> DeleteServiceAsync(int id);
        Task<List<ServiceResponse>> GetServicesAsync();
        Task<int> UpdateServiceAsync(int id, ServiceRequest request);
    }
}