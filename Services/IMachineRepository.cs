using AceMicEV.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface IMachineRepository
    {
        Task<MachineResponse> Machinedata(string barcodeNumber);

    }
}
