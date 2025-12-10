using Microsoft.EntityFrameworkCore;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;
using vendingbackend.Infrastructure.DataAccess;

namespace vendingbackend.Infrastructure.Repositories;

public class TradeApparatusRepository : ITradeApparatusRepository
{
    private readonly AppDbContext _appDbContext;

    public TradeApparatusRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<TradeApparatusResponse>> GetAllTradesAsync()
    {
        return await _appDbContext.TradeApparatus
            .AsNoTracking()
            .Select(s => new TradeApparatusResponse(s.Id,
            s.Model,
            s.Type.ToString(),
            s.SummaryIncome,
            s.SerialNumber,
            s.FirmName,
            s.DateCreated,
            s.DateUpdated,
            s.LastCheckDate,
            s.NextCheckInterval,
            s.Resource,
            s.NextRepairDate,
            s.RepairTime,
            s.Status.ToString(),
            s.CountryOfManufacturer,
            s.InventarizationTime,
            s.CheckedByUserId)).ToListAsync();
    }

    public async Task<int> CreateTradeAsync(TradeApparatusRequest request)
    {
        var ta = new TradeApparatus()
        {
            Model = request.Model,
            Type = (PayType)request.PayType,
            SummaryIncome = request.SummaryIncome,
            SerialNumber = request.SerialNumber,
            FirmName = request.FirmName,
            DateCreated = request.DateCreated,
            DateUpdated = request.DateUpdated,
            LastCheckDate = request.LastCheckDate,
            NextCheckInterval = request.NextCheckInterval,
            Resource = request.Resource,
            NextRepairDate = request.NextReapirDate,
            RepairTime = request.ReapirTime,
            Status = (Status)request.Status,
            CountryOfManufacturer = request.CountryOfManufacturer,
            InventarizationTime = request.InventarizationTime,
            CheckedByUserId = request.CheckedByUserId,
        };
        await _appDbContext.AddAsync(ta);
        await _appDbContext.SaveChangesAsync();
        return ta.Id;
    }

    public async Task<int> UpdateTradeApparatusAsync(int id, TradeApparatusRequest request)
    {
        await _appDbContext.TradeApparatus
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(t => t.Model, request.Model)
            .SetProperty(t => t.Type, (PayType)request.PayType)
            .SetProperty(t => t.SummaryIncome, request.SummaryIncome)
            .SetProperty(t => t.SerialNumber, request.SerialNumber)
            .SetProperty(t => t.FirmName, request.FirmName)
            .SetProperty(t => t.DateCreated, request.DateCreated)
            .SetProperty(t => t.DateUpdated, request.DateUpdated)
            .SetProperty(t => t.LastCheckDate, request.LastCheckDate)
            .SetProperty(t => t.NextCheckInterval, request.NextCheckInterval)
            .SetProperty(t => t.Resource, request.Resource)
            .SetProperty(t => t.NextRepairDate, request.NextReapirDate)
            .SetProperty(t => t.RepairTime, request.ReapirTime)
            .SetProperty(t => t.Status, (Status)request.Status)
            .SetProperty(t => t.CountryOfManufacturer, request.CountryOfManufacturer)
            .SetProperty(t => t.InventarizationTime, request.InventarizationTime)
            .SetProperty(t => t.CheckedByUserId, request.CheckedByUserId));
        await _appDbContext.SaveChangesAsync();
        return id;
    }

    public async Task<int> DeleteTradeApparatusAsync(int id)
    {
        await _appDbContext.TradeApparatus.Where(t => t.Id == id).ExecuteDeleteAsync();
        await _appDbContext.SaveChangesAsync();
        return id;
    }
}