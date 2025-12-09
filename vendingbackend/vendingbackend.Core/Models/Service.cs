namespace vendingbackend.Core.Models;

public class Service
{
    public int Id { get; set; }
    public int ApparatusId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Problems { get; set; } = string.Empty;
    public int UserId { get; set; }
    
    
    public virtual User User {get;set;}
    public virtual TradeApparatus Apparatus {get;set;}
}