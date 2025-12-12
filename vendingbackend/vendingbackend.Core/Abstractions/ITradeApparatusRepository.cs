using vendingbackend.Core.DTOs;

namespace vendingbackend.Infrastructure.Repositories
{
    public interface ITradeApparatusRepository
    {
        Task<TradeApparatusResponse?> GetTradeApparatusByIdAsync(int id);
        Task<int> CreateTradeAsync(TradeApparatusRequest request);
        Task<int> DeleteTradeApparatusAsync(int id);
        Task<List<TradeApparatusResponse>> GetAllTradesAsync();
        Task<int> UpdateTradeApparatusAsync(int id, TradeApparatusRequest request);
    }
}