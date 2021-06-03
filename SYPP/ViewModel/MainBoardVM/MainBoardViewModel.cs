using SYPP.Model.DB;
using SYPP.Model.DB.Companies;
using SYPP.Model.DB.Template;
using SYPP.Model.DTO.Calendar;
using SYPP.Model.DTO.General.Button;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.MainBoardVM
{
    public class MainBoardViewModel : BaseViewModel
    {
        public MainBoardViewModel()
        {

        }
        public async Task LoadData()
        {
            try
            {
                await InitNavigations();
                if (LocalStorage.IsMock)
                {
                    await LoadMockData();
                }
                else
                {
                    await LoadItems();
                }
                await LoadServices();
                await PopulateCalendarEvents();
            }
            catch(Exception ex)
            {

            }
        }



        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task LoadServices()
        {
            try
            {
                //await _socket.StartConnection();
                await _socket.StartConnection();
                await _socket.OnConnected_Init();
                //await _socket.OnConnected_Init();
                //ServiceContainer.Register<ICourseService>(() => new CourseService());            
                //ServiceContainer.Register<IChatService>(() => new ChatService());

                //var socketService = new SignalRSocketService();
                //await socketService.StartConnection();
                //ServiceContainer.Register<ISignalRSocketService>(() => socketService);
            }
            catch (Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        }
        public async Task InitNavigations()
        {
            try
            {
                Navigations = new ObservableCollection<Text_Button_DTO>();
                Navigations.Add(new Text_Button_DTO
                {
                    Text = "Calendar",
                    IconSource = "/Assets/Navigations/Calendar_Navigation_UnSelected_Icon.svg",
                    Background = "#363C46",
                    Background_Hover = "#7D8CA8",
                    Background_Pressed = "#94A5C5",
                    Foreground = "#C2DBFF",
                    Icon_Height = 13,
                    Icon_Width = 12
                });
                Navigations.Add(new Text_Button_DTO
                {
                    Text = "Applications",
                    IconSource = "/Assets/Navigations/Applications_Navigation_Selected_Icon.svg",
                    Background = "#C2DBFF",
                    Background_Hover = "#C2DBFF",
                    Background_Pressed = "#C2DBFF",
                    Foreground = "#1A1C20",
                    Icon_Height = 12,
                    Icon_Width = 12
                });
                Navigations.Add(new Text_Button_DTO
                {
                    Text = "Companies",
                    IconSource = "/Assets/Navigations/Applications_Navigation_UnSelected_Icon.svg",
                    Background = "#363C46",
                    Background_Hover = "#7D8CA8",
                    Background_Pressed = "#94A5C5",
                    Foreground = "#C2DBFF",
                    Icon_Height = 12,
                    Icon_Width = 12
                });
                Navigations.Add(new Text_Button_DTO
                {
                    Text = "Templates",
                    IconSource = "/Assets/Navigations/Templates_Navigation_UnSelected_Icon.svg",
                    Background = "#363C46",
                    Background_Hover = "#7D8CA8",
                    Background_Pressed = "#94A5C5",
                    Foreground = "#C2DBFF",
                    Icon_Height = 11,
                    Icon_Width = 12
                });

            }
            catch (Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        }
        public async Task PopulateCalendarEvents()
        {
            try
            {
                List<Task> Tasks = new List<Task>();
                //List of all the events (tasks)
                List<Calendar_Event_DTO> Events = new List<Calendar_Event_DTO>();
                if (LocalStorage.Applications != null)
                {
                    foreach (var app in LocalStorage.Applications)
                    {
                        if (app.Tasks != null)
                        {
                            foreach (var task in app.Tasks)
                            {
                                Calendar_Event_DTO _event = new Calendar_Event_DTO
                                {
                                    applicationID = app.applicationID,
                                    calendarEventID = Guid.NewGuid().ToString(),
                                    TaskType = "Task", 
                                    Task = task,
                                    Detail = app.Detail
                                };
                                Events.Add(_event);
                            }
                        }
                        //
                        //TODO account for other types of events 
                        //
                    }
                    await InitCalendarItems(Events);
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {

            }
        } //Initiate after applications lists are retrieved 
        public async Task LoadMockData()
        {
            try
            {
                LocalStorage.User = await _mock.GetUser();
                var applications = await _mock.GetApplications();
                var companies = await _mock.GetCompanies();
                LocalStorage.Companies = new ObservableCollection<Company>(companies);
                LocalStorage.Applications = new ObservableCollection<Model.DB.Application>(applications);
            }
            catch (Exception ex) { }
        }
        public async Task LoadItems()
        {
            try
            {
                if(LocalStorage.User != null)
                {
                    if(LocalStorage.User.ApplicationIDs != null && LocalStorage.User.ApplicationIDs.Count != 0)
                    {
                        var list = await _applicaiton.GetApplications();
                        LocalStorage.Applications = new ObservableCollection<Application>(list);
                    }
                    else
                    {
                        LocalStorage.Applications = new ObservableCollection<Application>();
                    }

                    if (LocalStorage.User.CompanyIDs != null && LocalStorage.User.CompanyIDs.Count != 0)
                    {
                        var list = await _company.GetCompanies();
                        LocalStorage.Companies = new ObservableCollection<Company>(list);
                    }
                    else
                    {
                        LocalStorage.Companies = new ObservableCollection<Company>();
                    }

                    if (LocalStorage.User.TemplateIDs != null && LocalStorage.User.TemplateIDs.Count != 0)
                    {
                        var list = await _template.GetTemplates();
                        LocalStorage.Templates = new ObservableCollection<Template>(list);
                    }
                    else
                    {
                        //TODO Initiate Tepmlates 
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task InitCalendarItems(List<Calendar_Event_DTO> list)
        {
            //Populate Calendar 
            LocalStorage.Calendar = new ObservableCollection<Daily_Tasks_DTO>();
            var YearToday = DateTime.Now.ToString("yyyy");
            var Year = int.Parse(YearToday);

            //Sets start and end date: last year and next year 
            LocalStorage.Start = new DateTime(Year - 1, 1, 1);
            LocalStorage.End = new DateTime(Year + 1, 12, 31);

            for (var year = Year - 1; year < Year + 2; year++)
            {
                for (var month = 1; month < 13; month++)
                {
                    //var temp = new DateTime(year, month, 1);
                    var numDays = DateTime.DaysInMonth(year, month);
                    for (var day = 1; day < numDays + 1; day++)
                    {

                        var date = new DateTime(year, month, day);
                        List<Calendar_Event_DTO> events = new List<Calendar_Event_DTO>();
                        if (list.Count != 0)
                        {
                            events = list.Where(x => x.Task.Time.Year == date.Year && x.Task.Time.Month == date.Month && x.Task.Time.Day == date.Day).ToList();
                        }
                        if (events.Count != 0)
                        {
                            var hi = 1;
                        }
                        Daily_Tasks_DTO daily = new Daily_Tasks_DTO
                        {
                            Date = date,
                            Events =  new ObservableCollection<Calendar_Event_DTO>(events)
                        };
                        LocalStorage.Calendar.Add(daily);
                    }
                }
            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________


        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________


        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> Navigations { get; set; }


        //___________________________________________________________________________________
        //
        // Template Methods
        //___________________________________________________________________________________

        public async Task Template_Init(object param1, object param2)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        }
    }
}
