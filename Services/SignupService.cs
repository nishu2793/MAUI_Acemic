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
    public class SignupService : ISignUpRepository
    {
        public async Task<bool> SignUp(string firstName, string lastName)
        {
            var SignUp = new UserInfo()
            {
                FirstName = firstName,
                LastName = lastName
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(SignUp);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/UserRegister/SaveUserRegister", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                var data = JsonConvert.DeserializeObject<AuthResponse>(details);

                var Firsttext = data.firstname;
                Preferences.Set("FirstKey", Firsttext);

                var Lasttext = data.lastname;
                Preferences.Set("LastKey", Lasttext);


                return true;
            }
            return false;

        }
    }
}