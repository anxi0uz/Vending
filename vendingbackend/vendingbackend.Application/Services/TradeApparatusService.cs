using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vendingbackend.Core.DTOs;
using vendingbackend.Infrastructure.Repositories;

namespace vendingbackend.Application.Services
{
    public class TradeApparatusService : ITradeApparatusService
    {
        public TradeApparatusService(ITradeApparatusRepository repository)
        {
            _repository = repository;
        }

        public ITradeApparatusRepository _repository { get; }

        public async Task<List<TradeApparatusResponse>> GetAllTradeApparatusesAsync()
        {
            return await _repository.GetAllTradesAsync();
        }
        //i hate juice
        public async Task<TradeApparatusResponse?> GetTradeApparatusByIdAsync(int id)
        {
            return await _repository.GetTradeApparatusByIdAsync(id);
        }
        public async Task<int> CreateTradeApparatusAsync(TradeApparatusRequest request)
        {
            return await _repository.CreateTradeAsync(request);
        }
        public async Task<int> UpdateTradeApparatusAsync(int id, TradeApparatusRequest request)
        {
            return await _repository.UpdateTradeApparatusAsync(id, request);
        }
        public async Task<int> DeleteTradeApparatusAsync(int id)
        {
            return await _repository.DeleteTradeApparatusAsync(id);
        }
    }
}
