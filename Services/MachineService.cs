using AceMicEV.Models;
using AceMicEV.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services;

public class MachineService : IMachineRepository
{
    public async Task<MachineResponse> Machinedata(string barcodeNumber)
    {
        var Machinedata = new MachineInfo
        {
            BarcodeNumber = barcodeNumber,
        };

        var rtnResponse = new MachineResponse();
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(Machinedata);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/Machine/GetMachinebyId", postData);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

            rtnResponse = JsonConvert.DeserializeObject<List<MachineResponse>>(details).FirstOrDefault();
            return rtnResponse;
            //return true;
        }
        return null;

    }
}

