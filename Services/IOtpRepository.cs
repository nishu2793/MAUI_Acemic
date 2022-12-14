using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public interface IOtpRepository
    {
        Task<bool> VerOtp(string did, string otp, string mobileno, string email);
    }
}