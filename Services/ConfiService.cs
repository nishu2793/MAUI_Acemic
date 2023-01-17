using AceMicEV.Models;
using AceMicEV.Models.Response;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceMicEV.Views;
using Android.Gms.Common.Apis;

namespace AceMicEV.Services
{
   public class ConfiService : IConfiRepository
    {
        public async Task<ConfiResponse> Condata(string machineId, string amount, string orderType, string userId)
        {
            var Condata = new OrderInfo
            {
                MachineID = machineId,
                Amount = amount,
                OrderType = orderType,
                UserID = userId,
            };

            var retnResponse = new ConfiResponse();
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(Condata);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/Order/SaveOrder", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                retnResponse = JsonConvert.DeserializeObject<List<ConfiResponse>>(details).FirstOrDefault();

                return retnResponse;


            }
            return null;

        }
    }
}
