using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.DTOs
{
    public record SalesRequest(int apparatusid, int productid, uint quantity, decimal totalprice, DateTime saledate, int PayType);
}
