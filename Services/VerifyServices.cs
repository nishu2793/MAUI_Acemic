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
    public class VerifyServices : IOtpRepository
    {
        public async Task<bool> VerOtp(string did, string otp, string mobileno, string email)
        {
            var userdata = new UserInfo()
            {
                Did = did,
                emailAddress = email,
                MobileNo = mobileno,
                OTP = otp,

            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(userdata);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/UserRegisterTemp/Verifyotp", postData);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

                var data = JsonConvert.DeserializeObject<List<VerifyResponse>>(details).FirstOrDefault();


                var otpText = data.otp;
                Preferences.Set("OtpKey", otpText);

                Preferences.Remove("DidKey");
                var didText = data.did.ToString();
                Preferences.Set("DidKey", didText);

                if (data.did != didText)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }
    }
}