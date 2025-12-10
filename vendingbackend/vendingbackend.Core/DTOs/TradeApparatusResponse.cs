namespace vendingbackend.Core.DTOs;

public record TradeApparatusResponse(
    int id, 
    string model,
    string Type,
    decimal SummaryIncome,
    Guid SerialNumber,
    string FirmName,
    DateOnly? DateCreated,
    DateOnly? DateUpdated,
    DateOnly? LastCheckDate,
    int NextCheckInterval,
    uint Resource,
    DateOnly? NextRepairDate,
    uint RepairTime,
    string Status,
    string CountryOfManufacturer,
    DateOnly? InventarizationTime,
    int? CheckedByUserId
    );
