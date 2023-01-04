using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Models.Response
{
   public class NotificationResponse
    {
        public string did { get; set; }

        public string data { get; set; }

        public string userId { get; set; }

        public string isRead { get; set; }

        public string readOn { get; set; }

        public string type { get; set; }

    }
}
