using vendingbackend.Core.DTOs;
using vendingbackend.Infrastructure.Repositories;

namespace vendingbackend.Application.Services
{
    public interface ITradeApparatusService
    {
        ITradeApparatusRepository _repository { get; }

        Task<int> CreateTradeApparatusAsync(TradeApparatusRequest request);
        Task<int> DeleteTradeApparatusAsync(int id);
        Task<List<TradeApparatusResponse>> GetAllTradeApparatusesAsync();
        Task<TradeApparatusResponse?> GetTradeApparatusByIdAsync(int id);
        Task<int> UpdateTradeApparatusAsync(int id, TradeApparatusRequest request);
    }
}