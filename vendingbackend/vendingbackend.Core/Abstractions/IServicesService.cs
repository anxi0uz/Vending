using vendingbackend.Core.DTOs;

namespace vendingbackend.Application.Services
{
    public interface IServicesService
    {
        Task<int> CreateServiceAsync(ServiceRequest request);
        Task<int> DeleteServiceAsync(int id);
        Task<List<ServiceResponse>> GetAllServicesAsync();
        Task<int> UpdateServiceAsync(int id, ServiceRequest request);
    }
}