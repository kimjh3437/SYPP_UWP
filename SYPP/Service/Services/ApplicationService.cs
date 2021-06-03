using Newtonsoft.Json;
using SYPP.Model.DB;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DB.Components.Tasks;
using SYPP.Model.DTO.Application;
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
    public class ApplicationService : IApplicationService
    {
        HttpClient client;
        public ApplicationService()
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

        //___________________________________________________________________________________
        //
        // Create/Update Handlers - Below
        //___________________________________________________________________________________
        public async Task<Application> CreateApplication(Application_Create_DTO param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/Create", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Application output = new Application();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Application>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<MidTask> CreateApplicationTask(MidTask param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateTask", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        MidTask output = new MidTask();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<MidTask>(temp);
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
        public async Task<bool> UpdateApplicationIsFavorite(Application_IsFavorite_Update_DTO param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdataeIsFavorite", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Note Related 
        public async Task<Note> CreateApplicationNote(Note param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateNote", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Note output = new Note();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Note>(temp);
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
        public async Task<Note> UpdateApplicationNote(Note param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdateNote", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Note output = new Note();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Note>(temp);
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
        public async Task<bool> DeleteApplicationNote(string applicationID, string noteID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/DeleteNote/{noteID}");
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Events Related 
        public async Task<Event> CreateApplicationEvent(Event param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateEvent", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Event output = new Event();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Event>(temp);
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
        public async Task<Event> UpdateApplicationEvent(Event param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdateEvent", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Event output = new Event();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Event>(temp);
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
        public async Task<bool> DeleteApplicationEvent(string applicationID, string eventID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/DeleteEvent/{eventID}");
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Contacts Related 
        public async Task<Contact> CreateApplicationContact(Contact param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateContact", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Contact output = new Contact();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Contact>(temp);
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
        public async Task<Contact> UpdateApplicationContact(Contact param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdateContact", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Contact output = new Contact();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Contact>(temp);
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
        public async Task<bool> DeleteApplicationContact(string applicationID, string contactID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/DeleteContact/{contactID}");
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Follow Up Related 
        public async Task<FollowUp> CreateApplicationFollowUp(FollowUp param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateFollowUp", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        FollowUp output = new FollowUp();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<FollowUp>(temp);
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
        public async Task<FollowUp> UpdateApplicationFollowUp(FollowUp param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdateFollowUp", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        FollowUp output = new FollowUp();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<FollowUp>(temp);
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
        public async Task<bool> DeleteApplicationFollowUp(string applicationID, string followUpID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/DeleteFollowUp/{followUpID}");
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Checklist Related 
        public async Task<Checklist> CreateApplicationChecklist(Checklist param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/CreateChecklist", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Checklist output = new Checklist();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Checklist>(temp);
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
        public async Task<Checklist> UpdateApplicationChecklist(Checklist param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/applications/{LocalStorage.User.uID}/UpdateChecklist", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Checklist output = new Checklist();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Checklist>(temp);
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
        public async Task<bool> DeleteApplicationChecklist(string applicationID, string checklistID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/DeleteChecklist/{checklistID}");
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //___________________________________________________________________________________
        //
        // GET Handlers - Below
        //___________________________________________________________________________________
        public async Task<List<Application>> GetApplications()
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/GetApplications");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Application> output = new List<Application>();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<List<Application>>(temp);
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
        public async Task<Application> GetApplication(string applicationID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/GetApplication/{applicationID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Application output = new Application();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Application>(temp);
                        return output;
                    }
                    return null;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<MidTask> GetApplicationMidTask(string midTaskID, string applicationID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/GetApplications/{applicationID}/GetMidTask/{midTaskID}");
                    if (response.IsSuccessStatusCode)
                    {
                        MidTask output = new MidTask();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<MidTask>(temp);
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

        //Note Related
        public async Task<Note> GetNote(string applicationID, string noteID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/GetNote/{noteID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Note output = new Note();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Note>(temp);
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


        //Events Related 
        public async Task<Event> GetEvent(string applicationID, string eventID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/GetEvent/{eventID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Event output = new Event();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Event>(temp);
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


        //Contact Related 
        public async Task<Contact> GetContact(string applicationID, string contactID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/GetContact/{contactID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Contact output = new Contact();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Contact>(temp);
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


        //Follow Up Related 
        public async Task<FollowUp> GetFollowUp(string applicationID, string followUpID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/GetFollowUp/{followUpID}");
                    if (response.IsSuccessStatusCode)
                    {
                        FollowUp output = new FollowUp();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<FollowUp>(temp);
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


        //Checklist Related
        public async Task<Checklist> GetChecklist(string applicationID, string checklistID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/applications/{LocalStorage.User.uID}/{applicationID}/GetChecklist/{checklistID}");
                    if (response.IsSuccessStatusCode)
                    {
                        Checklist output = new Checklist();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Checklist>(temp);
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
