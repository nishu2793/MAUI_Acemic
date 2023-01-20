using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public  interface ISignalRepository
    {
        Task<bool>Signaldata(string connectionId, string userId);
    }
}
