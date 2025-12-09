namespace vendingbackend.Core.Models;

public class Sales
{
    public int Id {get;set;}
    public int ApparatusId {get;set;}
    public int ProductId {get;set;}
    public uint Quantity {get;set;}
    public decimal TotalPrice {get;set;}
    public DateTime SaleDate {get;set;}
    public PayType PayType {get;set;}
    
    public virtual TradeApparatus Apparatus {get;set;}
    public virtual Product Product {get;set;}
}