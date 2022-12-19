using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Models.Response
{
    public class AuthResponse
    {  
        public string jwtToken { get; set; }

        public string emailId { get; set; }

        public string password { get; set; }

        public string userId { get; set; }

     
    }
}
