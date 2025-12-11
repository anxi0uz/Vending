using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingbackend.Core.DTOs
{
    public record ServiceResponse(int id, int apparatusId, DateOnly date, string description, string problems, int userid);
}
