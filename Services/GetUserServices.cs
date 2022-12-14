//using AceMicEV.Models;
//using AceMicEV.Models.Response;
//using DocumentFormat.OpenXml.Wordprocessing;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AceMicEV.Services
//{
//    public class GetUserServices : IGetRepository
//    {
//        public async Task<bool>getall(string did)
//        {
//            var getall = new UserInfo()
//            {
//                Did = did,
//            };
//                var httpClient = new HttpClient();
//                var json = JsonConvert.SerializeObject(getall);
//                var postData = new StringContent(json, Encoding.UTF8, "application/json");
//                var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/UserRegisterTemp/GetUserRegisterTemp", postData);
//                if (response.StatusCode == System.Net.HttpStatusCode.OK)
            
//            {
//                var jsonResponse = await response.Content.ReadAsStringAsync();
//                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

//                var data = JsonConvert.DeserializeObject<List<GetallResponse>>(details).FirstOrDefault();

//                var firsttext = data.FirstName;
//                Preferences.Set("FirstKey", firsttext);

//                var lastext = data.LastName;
//                Preferences.Set("LastKey", lastext);

//                var emailtext = data.emailAddress;
//                Preferences.Set("EmailKey", emailtext);

//                return true;
//            }
//            return false;
//        }
//    }
//}