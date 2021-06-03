using Newtonsoft.Json;
using SYPP.Model.DB;
using SYPP.Model.DB.Companies;
using SYPP.Model.DB.User;
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
    public class MockDataService : IMockDataService
    {
        HttpClient client;
        public MockDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{Configuration.BackendURL}");
        }
        public async Task<User> GetUser()
        {
            var response = await client.GetAsync($"/mockdata/getuser");
            if (response.IsSuccessStatusCode)
            {
                User user = new User();
                var temp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(temp);
                return user;
            }
            return null;
        }
        public async Task<List<Application>> GetApplications()
        {
            var response = await client.GetAsync($"/mockdata/getapplications");
            if (response.IsSuccessStatusCode)
            {
                List<Application> applications = new List<Application>();
                var temp = await response.Content.ReadAsStringAsync();
                applications = JsonConvert.DeserializeObject<List<Application>>(temp);
                return applications;
            }
            return null;
        }
        public async Task<List<Company>> GetCompanies()
        {
            var response = await client.GetAsync($"/mockdata/getcompanies");
            if (response.IsSuccessStatusCode)
            {
                List<Company> companies = new List<Company>();
                var temp = await response.Content.ReadAsStringAsync();
                companies = JsonConvert.DeserializeObject<List<Company>>(temp);
                return companies;
            }
            return null;
        }
        public async Task<List<Application>> GetTemplates()
        {
            var response = await client.GetAsync($"/mockdata/gettemplates");
            if (response.IsSuccessStatusCode)
            {
                List<Application> applications = new List<Application>();
                var temp = await response.Content.ReadAsStringAsync();
                applications = JsonConvert.DeserializeObject<List<Application>>(temp);
                return applications;
            }
            return null;
        }
    }
}
