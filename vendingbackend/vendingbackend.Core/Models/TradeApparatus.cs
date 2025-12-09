using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.Models
{
    public class TradeApparatus
    {
        public int ID { get; set; }

        public string Model { get; set; } = string.Empty;

        public ApparatusType Type { get; set; }

        public float SummaryIncome { get; set; }

        public Guid SerialNumber { get;set; }

        public string FirmName { get; set; } = string.Empty;

        public DateOnly? DateCreated { get; set; }

        public DateOnly? DateUpdated { get; set; }

        public DateOnly? LastCheckDate { get; set; }

        public int NextCheckInterval { get; set; }

        public uint Resource { get; set; }

        public DateOnly? NextRepireDate { get; set; }
        
        public uint RepireTime {  get; set; }

        public Status Status { get; set; }

        public string CountryOfManufacturer { get; set; } = string.Empty;

        public DateOnly? InventarizationTime { get; set; }
        
        public virtual User CheckedByUser { get; set; }

        public Guid CheckedByUserId { get; set; }
    }
    public enum ApparatusType
    {
        CardPay,CashPay
    }
    public enum Status
    {
        Working, OutOffOrder, InService
    }
}
