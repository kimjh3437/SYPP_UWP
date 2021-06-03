using SYPP.Model.DB.Components.Contents;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DTO.General.Button;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace SYPP.ViewModel.ComponentsVM.Event
{
    public class EventDetailedViewModel : BaseViewModel
    {
        public EventDetailedViewModel()
        {

        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();
                await PopulateCalendar();
                LoadFiles();
            }
            catch(Exception ex)
            {

            }
        }
        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeModels()
        {
            try
            {
                Contents = new ObservableCollection<Contents_Sub>();
                Files = new ObservableCollection<Model.DB.Components.File.File>();
                SelectedTime = DateTime.UtcNow;
                EachMonth = new ObservableCollection<Text_Button_DTO>();           
                if(Event != null)
                {
                    foreach(var item in Event.Contents)
                    {
                        Contents.Add(item);
                    }

                    Detail = Event.Detail;
                    Title = Event.Detail.Title;
                    Location = Event.Detail.Location;
                    SelectedTime = Event.Detail.Time.Date;
                    HH = Event.Detail.Time.Hour;
                    MM = Event.Detail.Time.Minute;
                    TT = Event.Detail.Time.ToString("tt");
                }
                else
                {
                    Detail = new Event_Detail();
                    Contents.Add(new Contents_Sub
                    {
                        noteContentsID = "noteContentsID",
                        Content = "Bring pinrted resume",
                        MarginType = 0
                    });
                }               
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task PopulateCalendar()
        {
            try
            {
                var month = SelectedTime.Month;
                DateTime month_prev = SelectedTime;
                DateTime month_next = SelectedTime;

                EachMonth.Clear();

                var date = new DateTime(SelectedTime.Year, SelectedTime.Month, 1); //selected month and year 
                var daysNum = DateTime.DaysInMonth(SelectedTime.Year, SelectedTime.Month); //numer of days in a month
                var startDay = (int)date.DayOfWeek; //starting day ex)monday, tuesday 
                var numOfNext = 35 - daysNum - startDay; //number of days next month
                if (startDay != 0)
                {
                    for (var x = startDay; x > 0; x--)
                    {
                        EachMonth.Add(new Text_Button_DTO
                        {
                            Text = "",
                            Visibility = Windows.UI.Xaml.Visibility.Collapsed
                        });
                    }
                }
                for (var x = 1; x < daysNum; x++)
                {
                    if (SelectedTime.Year == DateTime.Today.Year && SelectedTime.Month == DateTime.Today.Month && x == DateTime.Today.Day)
                    {
                        EachMonth.Add(new Text_Button_DTO
                        {
                            DateTime = new DateTime(SelectedTime.Year, SelectedTime.Month, x),
                            Visibility = Windows.UI.Xaml.Visibility.Visible,
                            Text = x.ToString(),
                            Foreground = "#C2DBFF"
                        });
                    }
                    else
                    {
                        EachMonth.Add(new Text_Button_DTO
                        {
                            DateTime = new DateTime(SelectedTime.Year, SelectedTime.Month, x),
                            Visibility = Windows.UI.Xaml.Visibility.Visible,
                            Text = x.ToString(),
                            Foreground = "#7D8CA8"
                        });
                    }

                }
                if (numOfNext != 0)
                {
                    for (var x = 0; x < numOfNext; x++)
                    {
                        EachMonth.Add(new Text_Button_DTO
                        {
                            Visibility = Windows.UI.Xaml.Visibility.Collapsed,
                            Text = x.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LoadFiles()
        {
            try
            {
                Files.Clear();
                if (Event != null)
                {
                    foreach(var item in Event.Files)
                    {
                        item.Preview_IsOpen = false;
                        item.Contents = await _file.GetFileSource(item.fileID);
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {
                            using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                            {
                                writer.WriteBytes(item.Contents);
                                await writer.StoreAsync();
                            }
                            var image = new BitmapImage();
                            await image.SetSourceAsync(stream);
                            item.ImageSource = image;
                        }
                        Files.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task SaveEvent()
        {
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (CreatingNewEvent)
                    {
                        Event = new Model.DB.Components.Events.Event();
                        Event.Detail = new Event_Detail();
                        Event.Detail.companyID = companyID;
                        Event.Detail.Title = Title;
                        Event.Detail.Location = Location;
                        Event.Detail.Time = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, HH, MM, 0);
                        Event.Contents = Contents.ToList();
                        Event.Files = Files.ToList();
                        var output = await _company.CreateCompanyEvent(Event);
                        if(output != null)
                        {
                            await _socket.Company_Events_Update_Init(companyID, output.Detail.eventID);
                        }
                    }
                    else
                    {
                        Event.Detail.companyID = companyID;
                        Event.Detail.Title = Title;
                        Event.Detail.Location = Location;
                        Event.Contents = Contents.ToList();
                        Event.Files = Files.ToList();
                        Event.Detail.Time = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, HH, MM, 0);
                        var output = await _applicaiton.UpdateApplicationEvent(Event);
                        if(output != null)
                        {
                            await _socket.Application_Events_Update_Init(companyID, output.Detail.eventID);
                        }           
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (CreatingNewEvent)
                    {
                        Event = new Model.DB.Components.Events.Event();
                        Event.Detail = new Event_Detail();
                        Event.Detail.applicationID = applicationID;
                        Event.Detail.Title = Title;
                        Event.Detail.Location = Location;
                        Event.Detail.Time = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, HH, MM, 0);
                        Event.Contents = Contents.ToList();
                        Event.Files = Files.ToList();
                        var output = await _applicaiton.CreateApplicationEvent(Event);
                        await _socket.Application_Events_Update_Init(output.Detail.applicationID, output.Detail.eventID);
                    }
                    else
                    {
                        Event.Detail.applicationID = applicationID;
                        Event.Detail.Title = Title;
                        Event.Detail.Location = Location;
                        Event.Contents = Contents.ToList();
                        Event.Files = Files.ToList();
                        Event.Detail.Time = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, HH, MM, 0);
                        var output = await _applicaiton.UpdateApplicationEvent(Event);
                        await _socket.Application_Events_Update_Init(output.Detail.applicationID, output.Detail.eventID);
                    }
                }
               
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteEvent()
        {
            try
            {
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (!CreatingNewEvent)
                    {
                        //Event.Detail.applicationID = applicationID;
                        //Event.Detail.Title = Title;
                        //Event.Detail.Location = Location;
                        //Event.Contents = Contents.ToList();
                        //Event.Detail.Time = new DateTime(SelectedTime.Year, SelectedTime.Month, SelectedTime.Day, HH, MM, 0);
                        var output = await _applicaiton.DeleteApplicationEvent(Event.Detail.applicationID, Event.Detail.eventID);
                        if (output)
                            await _socket.Application_Events_Delete_Init(Event.Detail.applicationID, Event.Detail.eventID);
                    }
                }
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (!CreatingNewEvent)
                    {
                        var output = await _company.DeleteCompanyEvent(Event.Detail.companyID, Event.Detail.eventID);
                        if (output)
                        {
                            await _socket.Company_Events_Delete_Init(Event.Detail.companyID, Event.Detail.eventID);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public SYPP.Model.DB.Components.Events.Event Event { get; set; }
        private Event_Detail _Detail;
        public Event_Detail Detail
        {
            get
            {
                return _Detail;
            }
            set
            {
                _Detail = value;
                OnPropertyChanged();
            }
        }
        private DateTime _SelectedTime;
        public DateTime SelectedTime
        {
            get
            {
                return _SelectedTime;
            }
            set
            {
                _SelectedTime = value;
                OnPropertyChanged();
            }
        }
        public int MM { get; set; }
        public int HH { get; set; }
        public string TT { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public bool CreatingNewEvent { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Contents_Sub> Contents { get; set; }
        public ObservableCollection<Text_Button_DTO> EachMonth { get; set; }
        public ObservableCollection<SYPP.Model.DB.Components.File.File> Files { get; set; }
    }
}
