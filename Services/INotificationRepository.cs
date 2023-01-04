using AceMicEV.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
     public interface INotificationRepository
    {
        Task<NotificationResponse> NotiData(string userid, string Type);
    }
}

