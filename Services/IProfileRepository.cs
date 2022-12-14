using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface IProfileRepository
    {
        Task<bool>Prodata(string did, string firstName, string lastName, string email, string mobileNo, string gender);
    }
}
