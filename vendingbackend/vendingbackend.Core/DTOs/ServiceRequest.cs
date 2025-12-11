using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.DTOs
{
    public record ServiceRequest(int apparatusid,DateOnly Date, string description, string problems, int UserId);
}
