
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Models.Response
{
    public class SignupResponse
    {
        public string did { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string emailAddress { get; set; }

        public string otp { get; set; }

        public string password { get; set; }

        public string mobileNo { get; set; }
        public string createdOn { get; set; }
        public string createdBy { get; set; }

    }
}
