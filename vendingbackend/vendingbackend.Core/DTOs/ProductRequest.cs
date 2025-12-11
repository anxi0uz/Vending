using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.DTOs
{
    public record ProductRequest(string name, string description, decimal price, uint quantity, uint minimalstock, decimal avgdailysales);
}
