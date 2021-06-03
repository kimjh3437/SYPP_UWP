using Newtonsoft.Json;
using SYPP.Model.DB.Template;
using SYPP.Service.Interfaces;
using SYPP.Utilities.Configurations;
using SYPP.Utilities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Services
{
    public class TemplateService : ITemplateService
    {
        HttpClient client;
        public TemplateService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{Configuration.BackendURL}");
        }

        public async Task<Template> CreateTemplate(Template param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/template/{LocalStorage.User.uID}/Create", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Template output = new Template();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Template>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Template> UpdateTemplate(Template param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/template/{LocalStorage.User.uID}/UpdateTemplate/{param.templateID}", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Template output = new Template();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Template>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Template> Get(string templateID)
        {
            try
            {
                if (templateID != null)
                {

                    var response = await client.GetAsync($"/template/{LocalStorage.User.uID}/GetTemplate/{templateID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Template output = new Template();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Template>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Template>> GetTemplates()
        {
            try
            {
                if (LocalStorage.User.uID != null)
                {

                    var response = await client.GetAsync($"/template/GetTemplates/{LocalStorage.User.uID}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Template> output = new List<Template>();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<List<Template>>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
