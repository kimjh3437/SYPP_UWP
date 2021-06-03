using Newtonsoft.Json;
using SYPP.Model.DB.User;
using SYPP.Model.DTO.Auth;
using SYPP.Model.DTO.Primitives;
using SYPP.Service.Interfaces;
using SYPP.Utilities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Services
{
    public class AuthService : IAuthService
    {
        HttpClient client;
        public AuthService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{Configuration.BackendURL}");
        }
        void SetAuthHeader(string token)
        {
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
            else
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
        }

        public async Task<bool> NameCheck(string username)
        {
            if (username != null)
            {
                StringClass str = new StringClass
                {
                    Content = username
                };
                var serialize = JsonConvert.SerializeObject(str);
                var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/auth/namecheck", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<User> Authenticate(User_Authenticate_DTO authenticate)
        {
            if (authenticate != null)
            {
                var serialize = JsonConvert.SerializeObject(authenticate);
                var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/auth/authenticate", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    User user = new User();
                    var temp = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(temp);
                    return user;
                }
                return null;

            }
            return null;
        }

        public async Task<User> Register(User_Register_DTO register)
        {
            if (register != null)
            {
                var serialize = JsonConvert.SerializeObject(register);
                var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"/auth/register", new StringContent(serialize, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    User user = new User();
                    var temp = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(temp);
                    return user;
                }
                return null;
            }
            return null;
        }
    }
}
