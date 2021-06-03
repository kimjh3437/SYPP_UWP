﻿using Newtonsoft.Json;
using SYPP.Model.DB.Companies;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DTO.Company;
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
    public class CompanyService : ICompanyService
    {
        HttpClient client;
        public CompanyService()
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
        public async Task<Company> CreateCompany(Company_Detail param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/Create", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        Company output = new Company();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Company>(temp);
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
        public async Task<bool> UpdateCompanyIsFavorite(Company_IsFavorite_Update_DTO param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdataeIsFavorite", stringContent);
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
        public async Task<Note> CreateCompanyNote(Note param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/CreateNote", stringContent);
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
        public async Task<Note> UpdateCompanyNote(Note param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdateNote", stringContent);
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
        public async Task<bool> DeleteCompanyNote(string companyID, string noteID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/company/{LocalStorage.User.uID}/{companyID}/DeleteNote/{noteID}");
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
        public async Task<Event> CreateCompanyEvent(Event param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/CreateEvent", stringContent);
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
        public async Task<Event> UpdateCompanyEvent(Event param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdateEvent", stringContent);
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
        public async Task<bool> DeleteCompanyEvent(string companyID, string eventID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/company/{LocalStorage.User.uID}/{companyID}/DeleteEvent/{eventID}");
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
        public async Task<Contact> CreateCompanyContact(Contact param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/CreateContact", stringContent);
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
        public async Task<Contact> UpdateCompanyContact(Contact param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdateContact", stringContent);
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
        public async Task<bool> DeleteCompanyContact(string companyID, string contactID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/company/{LocalStorage.User.uID}/{companyID}/DeleteContact/{contactID}");
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
        public async Task<FollowUp> CreateCompanyFollowUp(FollowUp param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/CreateFollowUp", stringContent);
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
        public async Task<FollowUp> UpdateCompanyFollowUp(FollowUp param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdateFollowUp", stringContent);
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
        public async Task<bool> DeleteCompanyFollowUp(string companyID, string followUpID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/company/{LocalStorage.User.uID}/{companyID}/DeleteFollowUp/{followUpID}");
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
        public async Task<Checklist> CreateCompanyChecklist(Checklist param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/CreateChecklist", stringContent);
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
        public async Task<Checklist> UpdateCompanyChecklist(Checklist param)
        {
            try
            {
                if (param != null)
                {
                    var serialize = JsonConvert.SerializeObject(param);
                    var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/company/{LocalStorage.User.uID}/UpdateChecklist", stringContent);
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
        public async Task<bool> DeleteCompanyChecklist(string companyID, string checklistID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.DeleteAsync($"/company/{LocalStorage.User.uID}/{companyID}/DeleteChecklist/{checklistID}");
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
        public async Task<List<Company>> GetCompanies()
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/GetCompanies");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Company> output = new List<Company>();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<List<Company>>(temp);
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
        public async Task<Company> GetCompany(string companyID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/GetCompany/{companyID}");
                    if (response.IsSuccessStatusCode)
                    {
                       Company output = new Company();
                        var temp = await response.Content.ReadAsStringAsync();
                        output = JsonConvert.DeserializeObject<Company>(temp);
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
        public async Task<Note> GetNote(string companyID, string noteID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/{companyID}/GetNote/{noteID}");
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
        public async Task<Event> GetEvent(string companyID, string eventID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/{companyID}/GetEvent/{eventID}");
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
        public async Task<Contact> GetContact(string companyID, string contactID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/{companyID}/GetContact/{contactID}");
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
        public async Task<FollowUp> GetFollowUp(string companyID, string followUpID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/{companyID}/GetFollowUp/{followUpID}");
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
        public async Task<Checklist> GetChecklist(string companyID, string checklistID)
        {
            try
            {
                if (LocalStorage.User?.uID != null)
                {
                    var response = await client.GetAsync($"/company/{LocalStorage.User.uID}/{companyID}/GetChecklist/{checklistID}");
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
