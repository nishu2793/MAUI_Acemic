using AceMicEV.Models;
using AceMicEV.Models.Response;
using Android.App;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services;
public class NotificationServices: INotificationRepository
{
     public async Task<NotificationResponse>NotiData(string userid, string Type)
    {
        var NotiData = new NotificationInfo
        {
            userId = userid,
            Notitype = Type,
        };
        var rtnNotiResponse = new NotificationResponse();
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(NotiData);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/Notification/GetNotification", postData);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

            //rtnNotiResponse = JsonConvert.DeserializeObject<List<NotificationResponse>>(details).FirstOrDefault();
            rtnNotiResponse = JsonConvert.DeserializeObject<List<NotificationResponse>>(details).FirstOrDefault();

            return rtnNotiResponse;
            //return true;
        }
        return null;

    }
}