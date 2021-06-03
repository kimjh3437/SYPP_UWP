using Microsoft.AspNetCore.SignalR.Client;
using SYPP.Service.Container;
using SYPP.Service.Interfaces;
using SYPP.Utilities.HubConnection;
using SYPP.Utilities.Storage;
using SYPP.View.Application;
using SYPP.View.Application.Detail;
using SYPP.View.Calendar;
using SYPP.View.Company;
using SYPP.View.Company.Detail;
using SYPP.View.Main;
using SYPP.View.Template;
using SYPP.ViewModel.ApplicationVM;
using SYPP.ViewModel.CalendarVM;
using SYPP.ViewModel.CompanyVM;
using SYPP.ViewModel.TemplateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SYPP.Service.Socket
{
    public class SignalRSocketHubService : ISignalRSocketHubService
    {
        private ITemplateService _template;
        private ICompanyService _company;
        private IApplicationService _application;
        public SignalRSocketHubService()
        {
            _template = ServiceContainer.Get<ITemplateService>();
            _company = ServiceContainer.Get<ICompanyService>();
            _application = ServiceContainer.Get<IApplicationService>();

            //___________________________________________________________________________________
            //
            // Application General Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string>("Application_Add_Update_Received", (applicationID) => Application_Add_Update_EventHandler?.Invoke(applicationID));
            Hubs.Connection.On<string, string>("Application_Task_Update_Received", (applicationID, midTaskID) => Application_Task_Update_EventHandler?.Invoke(applicationID, midTaskID));
            Hubs.Connection.On<string, bool>("Application_IsFavorite_Update_Received", (applicationID, IsFavorite) => Application_IsFavorite_Update_EventHandler?.Invoke(applicationID, IsFavorite));

            Application_Add_Update_EventHandler += Application_Add_Update_Received;
            Application_Task_Update_EventHandler += Application_Task_Update_Received;
            Application_IsFavorite_Update_EventHandler += Application_IsFavorite_Update_Received;

            //___________________________________________________________________________________
            //
            // Application Event Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Application_Events_Update_Received", (applicationID, eventID) => Application_Events_Update_EventHandler?.Invoke(applicationID, eventID));
            Hubs.Connection.On<string, string>("Application_Events_Delete_Received", (applicationID, eventID) => Application_Events_Delete_EventHandler?.Invoke(applicationID, eventID));

            Application_Events_Update_EventHandler += Application_Events_Update_Received;
            Application_Events_Delete_EventHandler += Application_Events_Delete_Received;

            //___________________________________________________________________________________
            //
            // Application Note Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Application_Notes_Update_Received", (applicationID, noteID) => Application_Notes_Update_EventHandler?.Invoke(applicationID, noteID));
            Hubs.Connection.On<string, string>("Application_Notes_Delete_Received", (applicationID, noteID) => Application_Notes_Delete_EventHandler?.Invoke(applicationID, noteID));

            Application_Notes_Update_EventHandler += Application_Notes_Update_Received;
            Application_Notes_Delete_EventHandler += Application_Notes_Delete_Received;

            //___________________________________________________________________________________
            //
            // Application Contact Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Application_Contacts_Update_Received", (applicationID, contactID) => Application_Contacts_Update_EventHandler?.Invoke(applicationID, contactID));
            Hubs.Connection.On<string, string>("Application_Contacts_Delete_Received", (applicationID, contactID) => Application_Contacts_Delete_EventHandler?.Invoke(applicationID, contactID));

            Application_Contacts_Update_EventHandler += Application_Contacts_Update_Received;
            Application_Contacts_Delete_EventHandler += Application_Contacts_Delete_Received;

            //___________________________________________________________________________________
            //
            // Application FollowUp Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Application_FollowUps_Update_Received", (applicationID, followUpID) => Application_FollowUps_Update_EventHandler?.Invoke(applicationID, followUpID));
            Hubs.Connection.On<string, string>("Application_FollowUps_Delete_Received", (applicationID, followUpID) => Application_FollowUps_Delete_EventHandler?.Invoke(applicationID, followUpID));

            Application_FollowUps_Update_EventHandler += Application_FollowUps_Update_Received;
            Application_FollowUps_Delete_EventHandler += Application_FollowUps_Delete_Received;

            //___________________________________________________________________________________
            //
            // Application Checklist Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Application_Checklists_Update_Received", (applicationID, checklistID) => Application_Checklists_Update_EventHandler?.Invoke(applicationID, checklistID));
            Hubs.Connection.On<string, string>("Application_Checklists_Delete_Received", (applicationID, checklistID) => Application_Checklists_Delete_EventHandler?.Invoke(applicationID, checklistID));

            Application_Checklists_Update_EventHandler += Application_Checklists_Update_Received;
            Application_Checklists_Delete_EventHandler += Application_Checklists_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Related Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string>("Company_Add_Update_Received", (companyID) => Company_Add_Update_EventHandler?.Invoke(companyID));
            Hubs.Connection.On<string, bool>("Company_IsFavorite_Update_Received", (companyID, IsFavorite) => Company_IsFavorite_Update_EventHandler?.Invoke(companyID, IsFavorite));

            Company_Add_Update_EventHandler += Company_Add_Update_Received;
            Company_IsFavorite_Update_EventHandler += Company_IsFavorite_Update_Received;

            //___________________________________________________________________________________
            //
            // Company Event Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Events_Update_Received", (companyID, eventID) => Company_Events_Update_EventHandler?.Invoke(companyID, eventID));
            Hubs.Connection.On<string, string>("Company_Events_Delete_Received", (companyID, eventID) => Company_Events_Delete_EventHandler?.Invoke(companyID, eventID));

            Company_Events_Update_EventHandler += Company_Events_Update_Received;
            Company_Events_Delete_EventHandler += Company_Events_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Note Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Notes_Update_Received", (companyID, noteID) => Company_Notes_Update_EventHandler?.Invoke(companyID, noteID));
            Hubs.Connection.On<string, string>("Company_Notes_Delete_Received", (companyID, noteID) => Company_Notes_Delete_EventHandler?.Invoke(companyID, noteID));

            Company_Notes_Update_EventHandler += Company_Notes_Update_Received;
            Company_Notes_Delete_EventHandler += Company_Notes_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Contact Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Contacts_Update_Received", (companyID, contactID) => Company_Contacts_Update_EventHandler?.Invoke(companyID, contactID));
            Hubs.Connection.On<string, string>("Company_Contacts_Delete_Received", (companyID, contactID) => Company_Contacts_Delete_EventHandler?.Invoke(companyID, contactID));

            Company_Contacts_Update_EventHandler += Company_Contacts_Update_Received;
            Company_Contacts_Delete_EventHandler += Company_Contacts_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company FollowUp Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_FollowUps_Update_Received", (companyID, followUpID) => Company_FollowUps_Update_EventHandler?.Invoke(companyID, followUpID));
            Hubs.Connection.On<string, string>("Company_FollowUps_Delete_Received", (companyID, followUpID) => Company_FollowUps_Delete_EventHandler?.Invoke(companyID, followUpID));

            Company_FollowUps_Update_EventHandler += Company_FollowUps_Update_Received;
            Company_FollowUps_Delete_EventHandler += Company_FollowUps_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Checklist Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Checklists_Update_Received", (companyID, checklistID) => Company_Checklists_Update_EventHandler?.Invoke(companyID, checklistID));
            Hubs.Connection.On<string, string>("Company_Checklists_Delete_Received", (companyID, checklistID) => Company_Checklists_Delete_EventHandler?.Invoke(companyID, checklistID));

            Company_Checklists_Update_EventHandler += Company_Checklists_Update_Received;
            Company_Checklists_Delete_EventHandler += Company_Checklists_Delete_Received;

            //___________________________________________________________________________________
            //
            // Template Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string>("Template_Create_Received", (templateID) => Template_Create_EventHandler?.Invoke(templateID));
            Hubs.Connection.On<string, bool>("Template_Update_Received", (templateID, IsDelete) => Template_Update_EventHandler?.Invoke(templateID, IsDelete));

            Template_Create_EventHandler += Template_Create_Received;
            Template_Update_EventHandler += Template_Update_Received;
        }

        //___________________________________________________________________________________
        //
        // Initial Connection Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task OnConnected_Init()
        {
            try
            {
                await Hubs.Connection.SendAsync("OnConnected", LocalStorage.User.uID, Hubs.Connection.ConnectionId);
            }
            catch (Exception ex)
            {
                Console.Write($"<OnConnected_Init> : {ex}");
            }
        }
        public async Task OnDisconnected_Init()
        {
            try
            {
                await Hubs.Connection.SendAsync("OnDisconnected", LocalStorage.User.uID);
            }
            catch (Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        }
        public async Task UpdateConnectionID_Init()
        {
            try
            {
                await Hubs.Connection.SendAsync("UpdateConnectionID", LocalStorage.User.uID, Hubs.Connection.ConnectionId);
            }
            catch (Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Application General Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_Add_Update_Init(string applicationID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Add_Update", LocalStorage.User.uID, applicationID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Add_Update_Init> : {ex}");
            }
        }
        public async Task Application_IsFavorite_Update_Init(string applicationID, bool IsFavorite)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_IsFavorite_Update", LocalStorage.User.uID, applicationID, IsFavorite);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_IsFavorite_Update_Init> : {ex}");
            }
        }
        public async Task Application_Task_Update_Init(string applicationID, string midTaskID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Task_Update", LocalStorage.User.uID, applicationID, midTaskID);
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application Event Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_Events_Update_Init(string applicationID, String eventID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Events_Update", LocalStorage.User.uID, applicationID, eventID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Events_Update_Init> : {ex}");
            }
        }
        public async Task Application_Events_Delete_Init(string applicationID, String eventID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Events_Delete", LocalStorage.User.uID, applicationID, eventID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Events_Update_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Application Note Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_Notes_Update_Init(string applicationID, String noteID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Notes_Update", LocalStorage.User.uID, applicationID, noteID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Notes_Update_Init> : {ex}");
            }
        }
        public async Task Application_Notes_Delete_Init(string applicationID, String noteID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Notes_Delete", LocalStorage.User.uID, applicationID, noteID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Notes_Update_Init> : {ex}");
            }
        }


        //___________________________________________________________________________________
        //
        // Application Contact Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_Contacts_Update_Init(string applicationID, String contactID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Contacts_Update", LocalStorage.User.uID, applicationID, contactID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Contacts_Update_Init> : {ex}");
            }
        }
        public async Task Application_Contacts_Delete_Init(string applicationID, String contactID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Contacts_Delete", LocalStorage.User.uID, applicationID, contactID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Contacts_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Application FollowUp Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_FollowUps_Update_Init(string applicationID, String followUpID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_FollowUps_Update", LocalStorage.User.uID, applicationID, followUpID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_FollowUps_Update_Init> : {ex}");
            }
        }
        public async Task Application_FollowUps_Delete_Init(string applicationID, String followUpID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_FollowUps_Delete", LocalStorage.User.uID, applicationID, followUpID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_FollowUps_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Application Checklist Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Application_Checklists_Update_Init(string applicationID, String checklistID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Checklists_Update", LocalStorage.User.uID, applicationID, checklistID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Checklists_Update_Init> : {ex}");
            }
        }
        public async Task Application_Checklists_Delete_Init(string applicationID, String checklistID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Application_Checklists_Delete", LocalStorage.User.uID, applicationID, checklistID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Application_Checklists_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company Related Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_Add_Update_Init(string companyID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Add_Update", LocalStorage.User.uID, companyID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Add_Update_Init> : {ex}");
            }
        }
        public async Task Company_IsFavorite_Update_Init(string companyID, bool IsFavorite)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_IsFavorite_Update", LocalStorage.User.uID, companyID, IsFavorite);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_IsFavorite_Update_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company Event Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_Events_Update_Init(string companyID, string eventID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Events_Update", LocalStorage.User.uID, companyID, eventID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Events_Update_Init> : {ex}");
            }
        }
        public async Task Company_Events_Delete_Init(string companyID, string eventID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Events_Delete", LocalStorage.User.uID, companyID, eventID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Events_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company Note Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_Notes_Update_Init(string companyID, string noteID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Notes_Update", LocalStorage.User.uID, companyID, noteID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Notes_Update_Init> : {ex}");
            }
        }
        public async Task Company_Notes_Delete_Init(string companyID, string noteID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Notes_Delete", LocalStorage.User.uID, companyID, noteID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Notes_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company Contact Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_Contacts_Update_Init(string companyID, string contactID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Contacts_Update", LocalStorage.User.uID, companyID, contactID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Contacts_Update_Init> : {ex}");
            }
        }
        public async Task Company_Contacts_Delete_Init(string companyID, string contactID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Contacts_Delete", LocalStorage.User.uID, companyID, contactID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Contacts_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company FollowUp Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_FollowUps_Update_Init(string companyID, string followUpID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_FollowUpws_Update", LocalStorage.User.uID, companyID, followUpID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_FollowUps_Update_Init> : {ex}");
            }
        }
        public async Task Company_FollowUps_Delete_Init(string companyID, string followUpID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_FollowUpws_Delete", LocalStorage.User.uID, companyID, followUpID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_FollowUps_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Company Checklist Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Company_Checklists_Update_Init(string companyID, string checklistID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Checklists_Update", LocalStorage.User.uID, companyID, checklistID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Checklists_Update_Init> : {ex}");
            }
        }
        public async Task Company_Checklists_Delete_Init(string companyID, string checklistID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Company_Checklists_Delete", LocalStorage.User.uID, companyID, checklistID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Company_Checklists_Delete_Init> : {ex}");
            }
        }

        //___________________________________________________________________________________
        //
        // Template Related Init Methods- Below 
        //___________________________________________________________________________________
        public async Task Template_Create_Init(string templateID)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Template_Create", LocalStorage.User.uID, templateID);
            }
            catch (Exception ex)
            {
                Console.Write($"<Template_Create_Init> : {ex}");
            }
        }
        public async Task Template_Update_Init(string templateID, bool IsDelete)
        {
            try
            {
                await UpdateConnectionID_Init();
                await Hubs.Connection.SendAsync("Template_Update", LocalStorage.User.uID, templateID, IsDelete);
            }
            catch (Exception ex)
            {
                Console.Write($"<Template_Update_Init> : {ex}");
            }
        }


        //___________________________________________________________________________________
        // /////////////////////////////////////////////////////////////////////////////////
        // LISTENERS BELOW 
        // /////////////////////////////////////////////////////////////////////////////////
        //___________________________________________________________________________________

        //Template 
        async void TemplateListener()
        {
            try
            {
                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Calendar Page 
                if (LocalStorage.Coordinate >= 10 && LocalStorage.Coordinate < 20)
                {
                    var content = main.Main_Contents_Frame.Content as CalendarPage;
                    if (content != null)
                    {
                        var contentVM = (CalendarViewModel)content.DataContext;
                        if (contentVM != null)
                        {

                        }
                    }
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {

                        }
                    }
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {

                        }
                    }
                }

                //When user is on Templates Page 
                if (LocalStorage.Coordinate >= 40 && LocalStorage.Coordinate < 50)
                {

                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application General Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_Add_Update_Received(string applicationID)
        {
            try
            {
                var application = await _application.GetApplication(applicationID);
                if (application == null)
                    return;

                //Add To Local Storage Applications 
                if(!LocalStorage.Applications.Where(x => x.applicationID == application.applicationID).Any())
                {
                    LocalStorage.Applications.Add(application);
                }

                String calendarEventID = Guid.NewGuid().ToString();
                //Add To Local Storage Calendar 
                if (application.Detail.Status != null && application.Detail.Status.Count != 0)
                {
                    if (application.Detail.Status[0].IsVisible)
                    {
                        var time = LocalStorage.Calendar.Where(x => x.Date.Month == application.Detail.Status[0].Time.Month && x.Date.Day == application.Detail.Status[0].Time.Day).FirstOrDefault();
                        if(time != null)
                        {
                            time.Events.Add(new Model.DTO.Calendar.Calendar_Event_DTO
                            {
                                applicationID = application.applicationID, 
                                calendarEventID = calendarEventID,
                                TaskType = "Status",
                                Task = application.Detail.Status[0],
                                Detail = application.Detail
                            });
                        }
                    }
                }

                var frame = Window.Current.Content as Frame;
                if(frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if(main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Calendar Page 
                if(LocalStorage.Coordinate >= 10 && LocalStorage.Coordinate < 20)
                {
                    var content = main.Main_Contents_Frame.Content as CalendarPage;
                    if(content != null)
                    {
                        var contentVM = (CalendarViewModel)content.DataContext;
                        if(contentVM != null)
                        {
                            //Add To Local Storage Calendar 
                            if (application.Detail.Status != null && application.Detail.Status.Count != 0)
                            {
                                if (application.Detail.Status[0].IsVisible)
                                {
                                    var time = contentVM.EachMonth.Where(x => x.Date.Month == application.Detail.Status[0].Time.Month && x.Date.Day == application.Detail.Status[0].Time.Day).FirstOrDefault();
                                    if (time != null)
                                    {
                                        if(!time.Events.Where(x => x.calendarEventID == calendarEventID).Any())
                                        {
                                            time.Events.Add(new Model.DTO.Calendar.Calendar_Event_DTO
                                            {
                                                applicationID = application.applicationID,
                                                calendarEventID = calendarEventID,
                                                TaskType = "Status",
                                                Task = application.Detail.Status[0],
                                                Detail = application.Detail
                                            });
                                        } 
                                    }
                                }
                            }
                        }
                    }
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if(!contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                contentVM.Applications.Add(application);
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }
        public async void Application_Task_Update_Received(string applicationID, string midTaskID)
        {
            try
            {
                var task = await _application.GetApplicationMidTask(midTaskID, applicationID);
                if (task == null)
                    return;

                //Add Tasks To The Corresponding Application
                var app = LocalStorage.Applications.Where(x => x.applicationID == task.applicationID).FirstOrDefault();
                if(app != null)
                {
                    if (!app.Tasks.Where(x => x.midTaskID == task.midTaskID).Any())
                        app.Tasks.Add(task);
                }

                var calendarDTO = new Model.DTO.Calendar.Calendar_Event_DTO
                {
                    applicationID = task.applicationID,
                    calendarEventID = Guid.NewGuid().ToString(),
                    TaskType = task.Type,
                    Task = task,
                    Detail = LocalStorage.Applications.Where(x => x.applicationID == task.applicationID).FirstOrDefault().Detail
                };
                if (task.IsVisible)
                {
                    var calendar = LocalStorage.Calendar.Where(x => x.Date.Year == task.Time.Year && x.Date.Month == task.Time.Month && x.Date.Day == task.Time.Day).FirstOrDefault();
                    if (calendar != null)
                    {
                        calendar.Events.Add(calendarDTO);
                    }
                }

                

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Calendar Page 
                if (LocalStorage.Coordinate >= 10 && LocalStorage.Coordinate < 20)
                {
                    var content = main.Main_Contents_Frame.Content as CalendarPage;
                    if (content != null)
                    {
                        var contentVM = (CalendarViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            var day = contentVM.EachMonth.Where(x => x.Date.Year == task.Time.Year && x.Date.Month == task.Time.Month && x.Date.Day == task.Time.Day).FirstOrDefault();
                            day.Events.Add(calendarDTO);
                            day.UpdateBorderColor();
                        }
                    }
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            var application = contentVM.Applications.Where(x => x.applicationID == task.applicationID).FirstOrDefault();
                            if(application != null)
                            {
                                if(!application.Tasks.Where(x => x.midTaskID == task.midTaskID).Any())
                                    application.Tasks.Add(task);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_IsFavorite_Update_Received(string applicationID, bool IsFavorite)
        {
            try
            {
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if(application != null)
                {
                    application.Detail.IsFavorite = IsFavorite;
                    application.UpdateFavoriteStatus();
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Calendar Page 
                if (LocalStorage.Coordinate >= 10 && LocalStorage.Coordinate < 20)
                {
                    var content = main.Main_Contents_Frame.Content as CalendarPage;
                    if (content != null)
                    {
                        var contentVM = (CalendarViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if(contentVM.EachMonth.Where(x => x.Events.Where(z => z.applicationID == applicationID).Any()).Any())
                            {
                                var list = contentVM.EachMonth.Where(x => x.Events.Where(z => z.applicationID == applicationID).Any()).ToList();

                                foreach(var item in list)
                                {
                                    if(item.Events != null && item.Events.Count != 0)
                                    {
                                        foreach (var ap in item.Events)
                                        {
                                            ap.Task.IsFavorite = IsFavorite;
                                            ap.Detail.IsFavorite = IsFavorite;
                                            ap.UpdateUI();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            var app = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                            if(app != null)
                            {
                                app.Detail.IsFavorite = IsFavorite;
                                app.UpdateFavoriteStatus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application Event Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_Events_Update_Received(string applicationID, string eventID)
        {
            try
            {
                var application_event = await _application.GetEvent(applicationID, eventID);
                if (application_event == null)
                    return;

                //Update Local Storage 
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if(application != null)
                {
                    if(application.Events.Where(x => x.Detail.eventID == eventID).Any())
                    {
                        var item = application.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                        var index = application.Events.IndexOf(item);
                        application.Events.RemoveAt(index);
                        application.Events.Insert(index, application_event);
                    }
                    else
                    {
                        application.Events.Add(application_event);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Calendar Page 
                if (LocalStorage.Coordinate >= 10 && LocalStorage.Coordinate < 20)
                {
                    var content = main.Main_Contents_Frame.Content as CalendarPage;
                    if (content != null)
                    {
                        var contentVM = (CalendarViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            //TODO Update Calendar when event is added 
                        }
                    }
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if(contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();               
                                var item_event = item.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                var index = item.Events.IndexOf(item_event);
                                item.Events.RemoveAt(index);
                                item.Events.Insert(index, application_event);
                            }
                            else
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                item.Events.Add(application_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if(contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            var index = detailVM.Events.IndexOf(item_event);
                                            detailVM.Events.RemoveAt(index);
                                            detailVM.Events.Insert(index, application_event);
                                        }
                                        else
                                        {
                                            detailVM.Events.Insert(0, application_event);
                                        }
                                    }
                                }
                            }           
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_Events_Delete_Received(string applicationID, string eventID)
        {
            try
            {
                var app = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if(app != null)
                {
                    app.Events.Remove(app.Events.Where(x => x.eventID == eventID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                item.Events.Remove(item_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            detailVM.Events.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application Note Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_Notes_Update_Received(string applicationID, string noteID)
        {
            try
            {
                var application_note = await _application.GetNote(applicationID, noteID);
                if (application_note == null)
                    return;

                //Update Local Storage 
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (application != null)
                {
                    if (application.Notes.Where(x => x.Detail.noteID == noteID).Any())
                    {
                        var item = application.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                        var index = application.Notes.IndexOf(item);
                        application.Notes.RemoveAt(index);
                        application.Notes.Insert(index, application_note);
                    }
                    else
                    {
                        application.Notes.Add(application_note);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                if(item_event != null)
                                {
                                    var index = item.Notes.IndexOf(item_event);
                                    item.Notes.RemoveAt(index);
                                    item.Notes.Insert(index, application_note);
                                }
                                else
                                {
                                    item.Notes.Insert(0, application_note);
                                }
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            var index = detailVM.Notes.IndexOf(item_event);
                                            detailVM.Notes.RemoveAt(index);
                                            detailVM.Notes.Insert(index, application_note);
                                        }
                                        else
                                        {
                                            detailVM.Notes.Insert(0, application_note);
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                } 
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_Notes_Delete_Received(string applicationID, string noteID)
        {
            try
            {
                var app = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (app != null)
                {
                    app.Notes.Remove(app.Notes.Where(x => x.noteID == noteID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                item.Notes.Remove(item_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.Notes.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application Contact Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_Contacts_Update_Received(string applicationID, string contactID)
        {
            try
            {
                var application_contact = await _application.GetContact(applicationID, contactID);
                if (application_contact == null)
                    return;

                //Update Local Storage 
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (application != null)
                {
                    if (application.Contacts.Where(x => x.Detail.contactID == contactID).Any())
                    {
                        var item = application.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                        var index = application.Contacts.IndexOf(item);
                        application.Contacts.RemoveAt(index);
                        application.Contacts.Insert(index, application_contact);
                    }
                    else
                    {
                        application.Contacts.Add(application_contact);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                if(item_event != null)
                                {
                                    var index = item.Contacts.IndexOf(item_event);
                                    item.Contacts.RemoveAt(index);
                                    item.Contacts.Insert(index, application_contact);
                                }
                                else
                                {
                                    item.Contacts.Insert(0, application_contact);
                                }
                            }


                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            var index = detailVM.Contacts.IndexOf(item_event);
                                            detailVM.Contacts.RemoveAt(index);
                                            detailVM.Contacts.Insert(index, application_contact);
                                        }
                                        else
                                        {
                                            detailVM.Contacts.Insert(0, application_contact);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_Contacts_Delete_Received(string applicationID, string contactID)
        {
            try
            {
                var app = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (app != null)
                {
                    app.Contacts.Remove(app.Contacts.Where(x => x.contactID == contactID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                item.Contacts.Remove(item_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.Contacts.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application FollowUp Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_FollowUps_Update_Received(string applicationID, string followUpID)
        {
            try
            {
                var application_followup = await _application.GetFollowUp(applicationID, followUpID);
                if (application_followup == null)
                    return;

                //Update Local Storage 
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (application != null)
                {
                    if (application.FollowUps.Where(x => x.Detail.followUpID == followUpID).Any())
                    {
                        var item = application.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                        var index = application.FollowUps.IndexOf(item);
                        application.FollowUps.RemoveAt(index);
                        application.FollowUps.Insert(index, application_followup);
                    }
                    else
                    {
                        application.FollowUps.Add(application_followup);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                if(item_event != null)
                                {
                                    var index = item.FollowUps.IndexOf(item_event);
                                    item.FollowUps.RemoveAt(index);
                                    item.FollowUps.Insert(index, application_followup);
                                }
                                else
                                {
                                    item.FollowUps.Insert(0, application_followup);
                                }
                                
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            var index = detailVM.FollowUps.IndexOf(item_event);
                                            detailVM.FollowUps.RemoveAt(index);
                                            detailVM.FollowUps.Insert(index, application_followup);
                                        }
                                        else
                                        {
                                            detailVM.FollowUps.Insert(0, application_followup);
                                        }  
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_FollowUps_Delete_Received(string applicationID, string followUpID)
        {
            try
            {
                var app = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (app != null)
                {
                    app.FollowUps.Remove(app.FollowUps.Where(x => x.followUpID == followUpID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                item.FollowUps.Remove(item_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.FollowUps.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Application Checklist Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Application_Checklists_Update_Received(string applicationID, string checklistID)
        {
            try
            {
                var application_checklist = await _application.GetChecklist(applicationID, checklistID);
                if (application_checklist == null)
                    return;

                //Update Local Storage 
                var application = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (application != null)
                {
                    if (application.Checklists.Where(x => x.checklistID == checklistID).Any())
                    {
                        var item = application.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                        var index = application.Checklists.IndexOf(item);
                        application.Checklists.RemoveAt(index);
                        application.Checklists.Insert(index, application_checklist);
                    }
                    else
                    {
                        application.Checklists.Add(application_checklist);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                if(item_event != null)
                                {
                                    var index = item.Checklists.IndexOf(item_event);
                                    item.Checklists.RemoveAt(index);
                                    item.Checklists.Insert(index, application_checklist);
                                }
                                else
                                {
                                    item.Checklists.Insert(0, application_checklist);
                                }
                                
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                        if(item_event != null)
                                        {
                                            var index = detailVM.Checklists.IndexOf(item_event);
                                            detailVM.Checklists.RemoveAt(index);
                                            detailVM.Checklists.Insert(index, application_checklist);
                                        }
                                        else
                                        {
                                            detailVM.Checklists.Insert(0, application_checklist);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Application_Checklists_Delete_Received(string applicationID, string checklistID)
        {
            try
            {
                var app = LocalStorage.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                if (app != null)
                {
                    app.Checklists.Remove(app.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                //When user is on Applications Page 
                if (LocalStorage.Coordinate >= 20 && LocalStorage.Coordinate < 30)
                {
                    var content = main.Main_Contents_Frame.Content as ApplicationsPage;
                    if (content != null)
                    {
                        var contentVM = (ApplicationViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Applications.Where(x => x.applicationID == applicationID).Any())
                            {
                                var item = contentVM.Applications.Where(x => x.applicationID == applicationID).FirstOrDefault();
                                var item_event = item.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                item.Checklists.Remove(item_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Application_Selected != null && contentVM.Application_Selected.applicationID == applicationID)
                            {
                                var detail = content.Application_Detail_Frame.Content as ApplicationDetailPage;
                                if (detail != null)
                                {
                                    var detailVM = (ApplicationDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.Checklists.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Related Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Add_Update_Received(string companyID)
        {
            try
            {
                var company = await _company.GetCompany(companyID);
                if (company == null)
                    return;

                //Add To Local Storage Applications 
                if (!LocalStorage.Companies.Where(x => x.companyID == company.companyID).Any())
                {
                    LocalStorage.Companies.Add(company);
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if(!contentVM.Companies.Where(x => x.companyID == company.companyID).Any())
                            {
                                contentVM.Companies.Insert(0, company);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_IsFavorite_Update_Received(string companyID, bool IsFavorite)
        {
            try
            {
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    company.Detail.IsFavorite = IsFavorite;
                    company.UpdateFavoriteStatus();
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            var item = contentVM.Companies.Where(x => x.companyID == company.companyID).FirstOrDefault();
                            if (item != null)
                            {
                                item.Detail.IsFavorite = IsFavorite;
                                item.UpdateFavoriteStatus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Event Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Events_Update_Received(string companyID, string eventID)
        {
            try
            {
                var company_event = await _company.GetEvent(companyID, eventID);
                if (company_event == null)
                    return;

                //Update Local Storage 
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    if (company.Events.Where(x => x.Detail.eventID == eventID).Any())
                    {
                        var item = company.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                        var index = company.Events.IndexOf(item);
                        company.Events.RemoveAt(index);
                        company.Events.Insert(index, company_event);
                    }
                    else
                    {
                        company.Events.Add(company_event);
                    }
                }
                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                var index = item.Events.IndexOf(item_event);
                                item.Events.RemoveAt(index);
                                item.Events.Insert(index, company_event);
                            }
                            else
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                item.Events.Add(company_event);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            var index = detailVM.Events.IndexOf(item_event);
                                            detailVM.Events.RemoveAt(index);
                                            detailVM.Events.Insert(index, company_event);
                                        }
                                        else
                                        {
                                            detailVM.Events.Insert(0, company_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //When user is on Templates Page 
                if (LocalStorage.Coordinate >= 40 && LocalStorage.Coordinate < 50)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Events_Delete_Received(string companyID, string eventID)
        {
            try
            {
                var app = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (app != null)
                {
                    app.Events.Remove(app.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                if(item_event != null)
                                {
                                    item.Events.Remove(item_event);
                                }
                            }

                            //Check if currently open detailed page is corresponding company 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.Events.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Note Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Notes_Update_Received(string companyID, string noteID)
        {
            try
            {
                var company_note = await _company.GetNote(companyID, noteID);
                if (company_note == null)
                    return;

                //Update Local Storage 
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    if (company.Notes.Where(x => x.Detail.noteID == noteID).Any())
                    {
                        var item = company.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                        var index = company.Notes.IndexOf(item);
                        company.Notes.RemoveAt(index);
                        company.Notes.Insert(index, company_note);
                    }
                    else
                    {
                        company.Notes.Add(company_note);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                var index = item.Notes.IndexOf(item_event);
                                item.Notes.RemoveAt(index);
                                item.Notes.Insert(index, company_note);
                            }
                            else
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                item.Notes.Add(company_note);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item = detailVM.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                        if (item!= null)
                                        {
                                            var index = detailVM.Notes.IndexOf(item);
                                            detailVM.Notes.RemoveAt(index);
                                            detailVM.Notes.Insert(index, company_note);
                                        }
                                        else
                                        {
                                            detailVM.Notes.Insert(0, company_note);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Notes_Delete_Received(string companyID, string noteID)
        {
            try
            {
                var app = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (app != null)
                {
                    app.Notes.Remove(app.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_delete = item.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                if (item_delete != null)
                                {
                                    item.Notes.Remove(item_delete);
                                }
                            }

                            //Check if currently open detailed page is corresponding company 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_event = detailVM.Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                                        if (item_event != null)
                                        {
                                            detailVM.Notes.Remove(item_event);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Contact Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Contacts_Update_Received(string companyID, string contactID)
        {
            try
            {
                var company_contact = await _company.GetContact(companyID, contactID);
                if (company_contact == null)
                    return;

                //Update Local Storage 
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    if (company.Contacts.Where(x => x.Detail.contactID == contactID).Any())
                    {
                        var item = company.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                        var index = company.Contacts.IndexOf(item);
                        company.Contacts.RemoveAt(index);
                        company.Contacts.Insert(index, company_contact);
                    }
                    else
                    {
                        company.Contacts.Add(company_contact);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                var index = item.Contacts.IndexOf(item_event);
                                item.Contacts.RemoveAt(index);
                                item.Contacts.Insert(index, company_contact);
                            }
                            else
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                item.Contacts.Add(company_contact);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item = detailVM.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                        if (item != null)
                                        {
                                            var index = detailVM.Contacts.IndexOf(item);
                                            detailVM.Contacts.RemoveAt(index);
                                            detailVM.Contacts.Insert(index, company_contact);
                                        }
                                        else
                                        {
                                            detailVM.Contacts.Insert(0, company_contact);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Contacts_Delete_Received(string companyID, string contactID)
        {
            try
            {
                var app = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (app != null)
                {
                    app.Contacts.Remove(app.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_delete = item.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                if (item_delete != null)
                                {
                                    item.Contacts.Remove(item_delete);
                                }
                            }

                            //Check if currently open detailed page is corresponding company 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_delete= detailVM.Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                                        if (item_delete != null)
                                        {
                                            detailVM.Contacts.Remove(item_delete);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company FollowUp Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_FollowUps_Update_Received(string companyID, string followUpID)
        {
            try
            {
                var company_followup = await _company.GetFollowUp(companyID, followUpID);
                if (company_followup == null)
                    return;

                //Update Local Storage 
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    if (company.FollowUps.Where(x => x.Detail.followUpID == followUpID).Any())
                    {
                        var item = company.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                        var index = company.FollowUps.IndexOf(item);
                        company.FollowUps.RemoveAt(index);
                        company.FollowUps.Insert(index, company_followup);
                    }
                    else
                    {
                        company.FollowUps.Add(company_followup);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                var index = item.FollowUps.IndexOf(item_event);
                                item.FollowUps.RemoveAt(index);
                                item.FollowUps.Insert(index, company_followup);
                            }
                            else
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                item.FollowUps.Add(company_followup);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item = detailVM.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                        if (item != null)
                                        {
                                            var index = detailVM.FollowUps.IndexOf(item);
                                            detailVM.FollowUps.RemoveAt(index);
                                            detailVM.FollowUps.Insert(index, company_followup);
                                        }
                                        else
                                        {
                                            detailVM.FollowUps.Insert(0, company_followup);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_FollowUps_Delete_Received(string companyID, string followUpID)
        {
            try
            {
                var app = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (app != null)
                {
                    app.FollowUps.Remove(app.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_delete = item.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                if (item_delete != null)
                                {
                                    item.FollowUps.Remove(item_delete);
                                }
                            }

                            //Check if currently open detailed page is corresponding company 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_delete = detailVM.FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                                        if (item_delete != null)
                                        {
                                            detailVM.FollowUps.Remove(item_delete);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Checklist Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Checklists_Update_Received(string companyID, string checklistID)
        {
            try
            {
                var company_checklist = await _company.GetChecklist(companyID, checklistID);
                if (company_checklist == null)
                    return;

                //Update Local Storage 
                var company = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (company != null)
                {
                    if (company.Checklists.Where(x => x.checklistID == checklistID).Any())
                    {
                        var item = company.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                        var index = company.Checklists.IndexOf(item);
                        company.Checklists.RemoveAt(index);
                        company.Checklists.Insert(index, company_checklist);
                    }
                    else
                    {
                        company.Checklists.Add(company_checklist);
                    }
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_event = item.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                var index = item.Checklists.IndexOf(item_event);
                                item.Checklists.RemoveAt(index);
                                item.Checklists.Insert(index, company_checklist);
                            }
                            else
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                item.Checklists.Add(company_checklist);
                            }

                            //Check if currently open detailed page is corresponding application 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item = detailVM.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                        if (item != null)
                                        {
                                            var index = detailVM.Checklists.IndexOf(item);
                                            detailVM.Checklists.RemoveAt(index);
                                            detailVM.Checklists.Insert(index, company_checklist);
                                        }
                                        else
                                        {
                                            detailVM.Checklists.Insert(0, company_checklist);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Checklists_Delete_Received(string companyID, string checklistID)
        {
            try
            {
                var app = LocalStorage.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                if (app != null)
                {
                    app.Checklists.Remove(app.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault());
                }

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }


                //When user is on Companies Page 
                if (LocalStorage.Coordinate >= 30 && LocalStorage.Coordinate < 40)
                {
                    var content = main.Main_Contents_Frame.Content as CompaniesPage;
                    if (content != null)
                    {
                        var contentVM = (CompanyViewModel)content.DataContext;
                        if (contentVM != null)
                        {
                            if (contentVM.Companies.Where(x => x.companyID == companyID).Any())
                            {
                                var item = contentVM.Companies.Where(x => x.companyID == companyID).FirstOrDefault();
                                var item_delete = item.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                if (item_delete != null)
                                {
                                    item.Checklists.Remove(item_delete);
                                }
                            }

                            //Check if currently open detailed page is corresponding company 
                            if (contentVM.Company_Selected != null && contentVM.Company_Selected.companyID == companyID)
                            {
                                var detail = content.Company_Detail_Frame.Content as CompanyDetailedPage;
                                if (detail != null)
                                {
                                    var detailVM = (CompanyDetailViewModel)detail.DataContext;
                                    if (detailVM != null)
                                    {
                                        var item_delete = detailVM.Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                                        if (item_delete != null)
                                        {
                                            detailVM.Checklists.Remove(item_delete);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Template Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Template_Create_Received(string templateID)
        {
            try
            {
                var template = await _template.Get(templateID);
                if (template == null)
                    return;

                if(!LocalStorage.Templates.Where(x => x.templateID == templateID).Any())
                {
                    LocalStorage.Templates.Insert(0, template);
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async void Template_Update_Received(string templateID, bool IsDelete)
        {
            try
            {
                var template = await _template.Get(templateID);
                if (template == null)
                    return;

                var frame = Window.Current.Content as Frame;
                if (frame == null)
                {
                    frame = Window.Current.Content as Frame;
                }
                var main = frame.Content as MainBoard;
                if (main == null)
                {
                    main = frame.Content as MainBoard;
                }

                if (!IsDelete)
                {
                    if (LocalStorage.Templates.Where(x => x.templateID == templateID).Any())
                    {
                        //if(LocalStorage.Coordinate == 40)
                        //{
                        //    var templatepage = main.Main_Contents_Frame.Content as TemplatePage;
                        //    var vm = templatepage.DataContext as TemplateViewModel;
                        //    if(vm != null)
                        //    {
                        //        if(CalendarViewSelectedDatesChangedEventArgs )
                        //    }

                        //}
                        
                        var index = LocalStorage.Templates.IndexOf(LocalStorage.Templates.Where(x => x.templateID == templateID).FirstOrDefault());
                        LocalStorage.Templates.RemoveAt(index);
                        LocalStorage.Templates.Insert(index, template);
                    }
                    else
                    {
                        LocalStorage.Templates.Insert(0, template);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        // /////////////////////////////////////////////////////////////////////////////////
        // Event Handlers BELOW 
        // /////////////////////////////////////////////////////////////////////////////////
        //___________________________________________________________________________________
        //application related below 
        public event Action<string> Application_Add_Update_EventHandler;
        public event Action<string, string> Application_Task_Update_EventHandler;
        public event Action<string, bool> Application_IsFavorite_Update_EventHandler;
        public event Action<string, string> Application_Events_Update_EventHandler;
        public event Action<string, string> Application_Events_Delete_EventHandler;
        public event Action<string, string> Application_Notes_Update_EventHandler;
        public event Action<string, string> Application_Notes_Delete_EventHandler;
        public event Action<string, string> Application_Contacts_Update_EventHandler;
        public event Action<string, string> Application_Contacts_Delete_EventHandler;
        public event Action<string, string> Application_FollowUps_Update_EventHandler;
        public event Action<string, string> Application_FollowUps_Delete_EventHandler;
        public event Action<string, string> Application_Checklists_Update_EventHandler;
        public event Action<string, string> Application_Checklists_Delete_EventHandler;

        //company related below 
        public event Action<string> Company_Add_Update_EventHandler;
        public event Action<string, bool> Company_IsFavorite_Update_EventHandler;
        public event Action<string, string> Company_Events_Update_EventHandler;
        public event Action<string, string> Company_Events_Delete_EventHandler;
        public event Action<string, string> Company_Notes_Update_EventHandler;
        public event Action<string, string> Company_Notes_Delete_EventHandler;
        public event Action<string, string> Company_Contacts_Update_EventHandler;
        public event Action<string, string> Company_Contacts_Delete_EventHandler;
        public event Action<string, string> Company_FollowUps_Update_EventHandler;
        public event Action<string, string> Company_FollowUps_Delete_EventHandler;
        public event Action<string, string> Company_Checklists_Update_EventHandler;
        public event Action<string, string> Company_Checklists_Delete_EventHandler;

        //tepmlate related below
        public event Action<string> Template_Create_EventHandler;
        public event Action<string, bool> Template_Update_EventHandler;


        //___________________________________________________________________________________
        //
        // Utilities Related - Below 
        //___________________________________________________________________________________
        public async Task StartConnection()
        {
            //await _connection.StartAsync();
            await Hubs.Connection.StartAsync();
        }
    }
}




//___________________________________________________________________________________
//
// Application General Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Application Event Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Application Note Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Application Contact Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Application FollowUp Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Application Checklist Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company Related Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company Event Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company Note Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company Contact Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company FollowUp Related Listeners- Below 
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Company Checklist Related Listeners- Below 
//___________________________________________________________________________________
