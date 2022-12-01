using AceMicEV.Models;
using AceMicEV.Models.Response;
using AceMicEV.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
namespace AceMicEV;

  //public class LoginService : IUserRepository
  //{
  //  public async Task<bool> Login(string username, string password)
  //   {
  //      var login = new UserInfo()
  //      {
  //          EmailId = username,
  //          Password = password
  //      };
  //      var httpClient = new HttpClient();
  //      var json = JsonConvert.SerializeObject(login);
  //      var postData = new StringContent(json, Encoding.UTF8, "application/json");
  //      var response = await httpClient.PostAsync("https://papercareapi.azurewebsites.net/api/Account/authenticate", postData);
  //      if (response.StatusCode == System.Net.HttpStatusCode.OK)
  //      {
  //          var jsonResponse = await response.Content.ReadAsStringAsync();
  //          var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

  //          var data = JsonConvert.DeserializeObject<AuthResponse>(details);

  //          //var tokentext = data.jwtToken;
  //          //Preferences.Set("TokenKey", tokentext);

  //          //var getToken = Preferences.Get("TokenKey", "Empty");

  //          var usertext = data.emailId;
  //          Preferences.Set("EmailKey", usertext);


  //          return true;
  //      }
  //      return false;

  //   }
  //}

public class LoginService : IUserRepository
{
    public async Task<bool> Login(string username, string password)
    {
        var login = new UserInfo()
        {
            EmailId = username,
            Password = password
        };
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(login);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("https://acemicapi.azurewebsites.net/api/Account/authenticate", postData);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var details = JsonConvert.SerializeObject(JObject.Parse(jsonResponse)["Data"]);

            var data = JsonConvert.DeserializeObject<AuthResponse>(details);

            var tokentext = data.jwtToken;
            Preferences.Set("TokenKey", tokentext);

            //var getToken = Preferences.Get("TokenKey", "Empty");

            var usertext = data.emailId;
            Preferences.Set("EmailKey", usertext);


            return true;
        }
        return false;

    }
}



