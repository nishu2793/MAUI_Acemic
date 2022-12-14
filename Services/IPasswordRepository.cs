using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface IPasswordRepository
    {
        Task<bool>Passmatch(string password, string did);

        Task<bool> getall(string did);
    }
}
