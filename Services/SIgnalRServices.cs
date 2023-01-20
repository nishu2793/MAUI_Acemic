using AceMicEV.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;


namespace AceMicEV.Services;

public class SIgnalRServices : ISignalRepository
{
    public async Task<bool> Signaldata(string connectionId, string userId)
   {
        var Signaldata = new SignalInfo
       {
            ConnectionId = connectionId,
            UserId = userId,
       };
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(Signaldata);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/SignalR/SaveSignalR", postData);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

            var data = JsonConvert.DeserializeObject(details).ToString();

            return true;
        }
        return false;

    }
}
