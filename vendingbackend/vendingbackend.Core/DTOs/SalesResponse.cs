using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.DTOs
{
    public record SalesResponse(int id, int apparatusId,int productid, uint quantity, decimal totalprice, DateTime saledate, string PayType);
}
