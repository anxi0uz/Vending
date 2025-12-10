using vendingbackend.Core.DTOs;
using vendingbackend.Infrastructure.DataAccess;

namespace vendingbackend.Infrastructure.Repositories;

public class TradeApparatusRepository
{
    private readonly AppDbContext _appDbContext;

    public TradeApparatusRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<TradeApparatusResponse>> GetAllTradesAsync()
    {
        return new List<TradeApparatusResponse>();
    }
}