using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface ISignalRSocketHubService
    {
        //___________________________________________________________________________________
        //
        // Init Methods- Below 
        //___________________________________________________________________________________
        
        //Initial Connections 
        Task OnConnected_Init();
        Task OnDisconnected_Init();
        Task UpdateConnectionID_Init();

        //application related below 
        Task Application_Add_Update_Init(string applicationID);
        Task Application_IsFavorite_Update_Init(string applicationID, bool IsFavorite);
        Task Application_Task_Update_Init(string applicationID, string midTaskID);
        Task Application_Events_Update_Init(string applicationID, String eventID);
        Task Application_Events_Delete_Init(string applicationID, String eventID);
        Task Application_Notes_Update_Init(string applicationID, String noteID);
        Task Application_Notes_Delete_Init(string applicationID, String noteID);
        Task Application_Contacts_Update_Init(string applicationID, String contactID);
        Task Application_Contacts_Delete_Init(string applicationID, String contactID);
        Task Application_FollowUps_Update_Init(string applicationID, String followUpID);
        Task Application_FollowUps_Delete_Init(string applicationID, String followUpID);
        Task Application_Checklists_Update_Init(string applicationID, String checklistID);
        Task Application_Checklists_Delete_Init(string applicationID, String checklistID);

        //company related 
        Task Company_Add_Update_Init(string companyID);
        Task Company_IsFavorite_Update_Init(string companyID, bool IsFavorite);
        Task Company_Events_Update_Init(string companyID, string eventID);
        Task Company_Events_Delete_Init(string companyID, string eventID);
        Task Company_Notes_Update_Init(string companyID, string noteID);
        Task Company_Notes_Delete_Init(string companyID, string noteID);
        Task Company_Contacts_Update_Init(string companyID, string contactID);
        Task Company_Contacts_Delete_Init(string companyID, string contactID);
        Task Company_FollowUps_Update_Init(string companyID, string followUpID);
        Task Company_FollowUps_Delete_Init(string companyID, string followUpID);
        Task Company_Checklists_Update_Init(string companyID, string checklistID);
        Task Company_Checklists_Delete_Init(string companyID, string checklistID);

        //Template Related
        Task Template_Create_Init(string templateID);
        Task Template_Update_Init(string templateID, bool IsDelete);

        //___________________________________________________________________________________
        //
        // Listener Methods- Below 
        //___________________________________________________________________________________

        //application related below 
        void Application_Add_Update_Received(string applicationID);
        void Application_Task_Update_Received(string applicationID, string midTaskID);
        void Application_IsFavorite_Update_Received(string applicationID, bool IsFavorite);
        void Application_Events_Update_Received(string applicationID, string eventID);
        void Application_Events_Delete_Received(string applicationID, string eventID);
        void Application_Notes_Update_Received(string applicationID, string noteID);
        void Application_Notes_Delete_Received(string applicationID, string noteID);
        void Application_Contacts_Update_Received(string applicationID, string contactID);
        void Application_Contacts_Delete_Received(string applicationID, string contactID);
        void Application_FollowUps_Update_Received(string applicationID, string followUpID);
        void Application_FollowUps_Delete_Received(string applicationID, string followUpID);
        void Application_Checklists_Update_Received(string applicationID, string checklistID);
        void Application_Checklists_Delete_Received(string applicationID, string checklistID);

        //company related below 
        void Company_Add_Update_Received(string companyID);
        void Company_IsFavorite_Update_Received(string companyID, bool IsFavorite);
        void Company_Events_Update_Received(string companyID, string eventID);
        void Company_Events_Delete_Received(string companyID, string eventID);
        void Company_Notes_Update_Received(string companyID, string noteID);
        void Company_Notes_Delete_Received(string companyID, string noteID);
        void Company_Contacts_Update_Received(string companyID, string contactID);
        void Company_Contacts_Delete_Received(string companyID, string contactID);
        void Company_FollowUps_Update_Received(string companyID, string followUpID);
        void Company_FollowUps_Delete_Received(string companyID, string followUpID);
        void Company_Checklists_Update_Received(string companyID, string checklistID);
        void Company_Checklists_Delete_Received(string companyID, string checklistID);

        //template related below 
        void Template_Create_Received(string templateID);
        void Template_Update_Received(string templateID, bool IsDelete);

        //___________________________________________________________________________________
        //
        // Event Handlers - Below 
        //___________________________________________________________________________________

        //application related below 
        event Action<string> Application_Add_Update_EventHandler;
        event Action<string, string> Application_Task_Update_EventHandler;
        event Action<string, bool> Application_IsFavorite_Update_EventHandler;
        event Action<string, string> Application_Events_Update_EventHandler;
        event Action<string, string> Application_Events_Delete_EventHandler;
        event Action<string, string> Application_Notes_Update_EventHandler;
        event Action<string, string> Application_Notes_Delete_EventHandler;
        event Action<string, string> Application_Contacts_Update_EventHandler;
        event Action<string, string> Application_Contacts_Delete_EventHandler;
        event Action<string, string> Application_FollowUps_Update_EventHandler;
        event Action<string, string> Application_FollowUps_Delete_EventHandler;
        event Action<string, string> Application_Checklists_Update_EventHandler;
        event Action<string, string> Application_Checklists_Delete_EventHandler;

        //company related below 
        event Action<string> Company_Add_Update_EventHandler;
        event Action<string, bool> Company_IsFavorite_Update_EventHandler;
        event Action<string, string> Company_Events_Update_EventHandler;
        event Action<string, string> Company_Events_Delete_EventHandler;
        event Action<string, string> Company_Notes_Update_EventHandler;
        event Action<string, string> Company_Notes_Delete_EventHandler;
        event Action<string, string> Company_Contacts_Update_EventHandler;
        event Action<string, string> Company_Contacts_Delete_EventHandler;
        event Action<string, string> Company_FollowUps_Update_EventHandler;
        event Action<string, string> Company_FollowUps_Delete_EventHandler;
        event Action<string, string> Company_Checklists_Update_EventHandler;
        event Action<string, string> Company_Checklists_Delete_EventHandler;

        //template related below 
        event Action<string, bool> Template_Update_EventHandler;
        event Action<string> Template_Create_EventHandler;


        //___________________________________________________________________________________
        //
        // Utilities Related - Below 
        //___________________________________________________________________________________
        Task StartConnection();
    }
}
