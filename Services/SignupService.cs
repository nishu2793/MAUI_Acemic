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
        public async Task<bool> SignUp(string firstName, string lastName, string emailAddress)
        {
            var SignUp = new UserInfo()
            {
                FirstName = firstName,
                LastName = lastName,
                emailAddress = emailAddress,
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(SignUp);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/UserRegisterTemp/SaveUserRegisterTemp", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
           
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                var data = JsonConvert.DeserializeObject<List<SignupResponse>>(details).FirstOrDefault();

                //var data = JsonConvert.DeserializeObject<SignupResponse>(details);

                Preferences.Remove("FirstKey");
                var firsttext = data.firstname;
                Preferences.Set("FirstKey", firsttext);

                Preferences.Remove("LastKey");
                var lastext = data.lastname;
                Preferences.Set("LastKey", lastext);

                Preferences.Remove("EmailKey");
                var emailtext = data.emailAddress;
                Preferences.Set("EmailKey", emailtext);

                Preferences.Remove("OtpKey");
                var otptext = data.otp;
                Preferences.Set("OtpKey", otptext);

                Preferences.Remove("DidKey");
                var didtext = data.did.ToString();
                Preferences.Set("DidKey", didtext);

                return true;
            }
            return false;

        }
    }
}