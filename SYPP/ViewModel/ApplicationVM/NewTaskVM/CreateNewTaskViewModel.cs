using SYPP.Model.DB.Components.Tasks;
using SYPP.Model.DTO.General.Button;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ApplicationVM.NewTaskVM
{
    public class CreateNewTaskViewModel : BaseViewModel
    {
        public CreateNewTaskViewModel()
        {

        }
        public async Task LoadData()
        {
            try
            {
                await InitNavigations();
                await InitModels();
                await PopulateCalendar();
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitNavigations()
        {
            try
            {
                Navigations = new ObservableCollection<Text_Button_DTO>
                {
                    new Model.DTO.General.Button.Text_Button_DTO
                    {
                        Text = "1",
                        Background = "#C2DBFF",
                        Foreground = "#242931",
                        Background_Hover = "#DBEAFF",
                        Background_Pressed = "#E3EFFF"

                    },
                    new Model.DTO.General.Button.Text_Button_DTO
                    {
                        Text = "2",
                        Background = "#363C46",
                        Foreground = "#242931",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5"

                    }
                };
            }
            catch (Exception ex)
            {

            }
        }
        public async Task InitModels()
        {
            try
            {
                SelectedTime = DateTime.Now;
                EachMonth = new ObservableCollection<Text_Button_DTO>();
                StepOptions = new ObservableCollection<Text_Button_DTO>(
                    new List<Text_Button_DTO> 
                    {
                        new Text_Button_DTO
                        {
                            Text = "Interview", 
                            Foreground = "#C2DBFF",
                            Background = "#363C46",
                            Background_Hover = "#7D8CA8",
                            Background_Pressed = "#94A5C5"
                        },
                        new Text_Button_DTO
                        {
                            Text = "Challenge",
                            Foreground = "#C2DBFF",
                            Background = "#363C46",
                            Background_Hover = "#7D8CA8",
                            Background_Pressed = "#94A5C5"
                        },
                        new Text_Button_DTO
                        {
                            Text = "Text",
                            Foreground = "#C2DBFF",
                            Background = "#363C46",
                            Background_Hover = "#7D8CA8",
                            Background_Pressed = "#94A5C5"
                        }
                    });
                
            }
            catch (Exception ex)
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
        public async Task AddMidTask()
        {
            try
            {
                
                MidTask midtask = new MidTask
                {
                    midTaskID = "",
                    Time = SelectedTime,
                    Status = TaskComplete,
                    IsFavorite = false,
                    IsVisible = DisplayDate,
                    companyID = "",
                    applicationID = applicationID
                };
                if (!String.IsNullOrEmpty(CustomSteps))
                {
                    midtask.Type = CustomSteps;
                }
                else
                {
                    if(Step_Selected != null)
                    {
                        midtask.Type = Step_Selected.Text;
                    }
                }
                var output = await _applicaiton.CreateApplicationTask(midtask);
                if(output != null)
                {
                    await _socket.Application_Task_Update_Init(applicationID, output.midTaskID);
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
        public string applicationID { set; get; }
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
        public string CustomSteps { get; set; }
        private Text_Button_DTO _Step_Selected;
        public Text_Button_DTO Step_Selected
        {
            get
            {
                return _Step_Selected;
            }
            set
            {
                _Step_Selected = value;
                OnPropertyChanged();
            }
        }
        public bool DisplayDate { get; set; }
        public bool TaskComplete { get; set; }
       

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> Navigations { get; set; }
        public ObservableCollection<Text_Button_DTO> EachMonth { get; set; }
        public ObservableCollection<Text_Button_DTO> StepOptions { get; set; }
    }
}
