using SYPP.Model.DB.Companies;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface ICompanyService
    {
        //___________________________________________________________________________________
        //
        // Create/Update Handlers - Below
        //___________________________________________________________________________________
        Task<Company> CreateCompany(Company_Detail param);
        Task<bool> UpdateCompanyIsFavorite(Company_IsFavorite_Update_DTO param);

        //Note Related 
        Task<Note> CreateCompanyNote(Note param);
        Task<Note> UpdateCompanyNote(Note param);
        Task<bool> DeleteCompanyNote(string companyID, string noteID);

        //Events Related 
        Task<Event> CreateCompanyEvent(Event param);
        Task<Event> UpdateCompanyEvent(Event param);
        Task<bool> DeleteCompanyEvent(string companyID, string eventID);

        //Contacts Related 
        Task<Contact> CreateCompanyContact(Contact param);
        Task<Contact> UpdateCompanyContact(Contact param);
        Task<bool> DeleteCompanyContact(string companyID, string contactID);

        //Follow Up Related 
        Task<FollowUp> CreateCompanyFollowUp(FollowUp param);
        Task<FollowUp> UpdateCompanyFollowUp(FollowUp param);
        Task<bool> DeleteCompanyFollowUp(string companyID, string followUpID);

        //Checklist Related 
        Task<Checklist> CreateCompanyChecklist(Checklist param);
        Task<Checklist> UpdateCompanyChecklist(Checklist param);
        Task<bool> DeleteCompanyChecklist(string companyID, string checklistID);


        //___________________________________________________________________________________
        //
        // GET Handlers - Below
        //___________________________________________________________________________________
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompany(string companyID);

        //Note Related
        Task<Note> GetNote(string companyID, string noteID);

        //Events Related 
        Task<Event> GetEvent(string companyID, string eventID);

        //Contact Related 
        Task<Contact> GetContact(string companyID, string contactID);

        //Follow Up Related 
        Task<FollowUp> GetFollowUp(string companyID, string followUpID);

        //Checklist Related
        Task<Checklist> GetChecklist(string companyID, string checklistID);

    }
}
