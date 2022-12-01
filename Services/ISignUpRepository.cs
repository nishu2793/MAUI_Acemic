using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface ISignUpRepository
    {
       Task<bool> SignUp(string firstName, string lastName);
    }
}
