using SYPP.Model.DB;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DB.Components.Tasks;
using SYPP.Model.DTO.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface IApplicationService
    {
        //___________________________________________________________________________________
        //
        // Create/Update Handlers - Below
        //___________________________________________________________________________________
        Task<Application> CreateApplication(Application_Create_DTO param);
        Task<MidTask> CreateApplicationTask(MidTask param);
        Task<bool> UpdateApplicationIsFavorite(Application_IsFavorite_Update_DTO param);

        //Note Related 
        Task<Note> CreateApplicationNote(Note param);
        Task<Note> UpdateApplicationNote(Note param);
        Task<bool> DeleteApplicationNote(string applicationID, string noteID);

        //Events Related 
        Task<Event> CreateApplicationEvent(Event param);
        Task<Event> UpdateApplicationEvent(Event param);
        Task<bool> DeleteApplicationEvent(string applicationID, string eventID);

        //Contacts Related 
        Task<Contact> CreateApplicationContact(Contact param);
        Task<Contact> UpdateApplicationContact(Contact param);
        Task<bool> DeleteApplicationContact(string applicationID, string contactID);

        //Follow Up Related 
        Task<FollowUp> CreateApplicationFollowUp(FollowUp param);
        Task<FollowUp> UpdateApplicationFollowUp(FollowUp param);
        Task<bool> DeleteApplicationFollowUp(string applicationID, string followUpID);

        //Checklist Related 
        Task<Checklist> CreateApplicationChecklist(Checklist param);
        Task<Checklist> UpdateApplicationChecklist(Checklist param);
        Task<bool> DeleteApplicationChecklist(string applicationID, string checklistID);

        //___________________________________________________________________________________
        //
        // GET Handlers - Below
        //___________________________________________________________________________________
        Task<List<Application>> GetApplications();
        Task<Application> GetApplication(string applicationID);
        Task<MidTask> GetApplicationMidTask(string midTaskID, string applicationID);

        //Note Related
        Task<Note> GetNote(string applicationID, string noteID);

        //Events Related 
        Task<Event> GetEvent(string applicationID, string eventID);

        //Contact Related 
        Task<Contact> GetContact(string applicationID, string contactID);

        //Follow Up Related 
        Task<FollowUp> GetFollowUp(string applicationID, string followUpID);

        //Checklist Related
        Task<Checklist> GetChecklist(string applicationID, string checklistID);

    }
}
