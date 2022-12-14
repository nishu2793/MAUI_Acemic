using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Models.Response
{
    public class VerifyResponse
    {
        public string did { get; set; }

        public string otp { get; set; }

        public string mobileNo { get; set; }

        public string email { get; set; }
    }
}
