using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface IConfiRepository
    {
        Task<bool> Condata(string machineId, string amount, string orderType, string userId);
    }
}
