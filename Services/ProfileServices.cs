using AceMicEV.Models;
using AceMicEV.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceMicEV.Services
{
    public class ProfileServices : IProfileRepository
    {

        public async Task<bool> Prodata(string did, string firstName, string lastName, string email,string mobileNo, string gender)
          {
            var Prodata = new UserInfo
            {
                Did = did,
                FirstName = firstName,
                LastName = lastName,
                emailAddress = email,
                MobileNo = mobileNo,
                Gender = gender,

            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(Prodata);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/UserRegister/SaveUserRegister", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                var data = JsonConvert.DeserializeObject(details).ToString();

                //Guid UserDid = data.DId;
                Preferences.Remove("DidKey");
                var didtext = data;
                Preferences.Set("DidKey", didtext);

                return true;
            }
            return false;

        }
    }
}
