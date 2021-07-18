using SYPP.Model.DB;
using SYPP.Model.DB.Components.Categories;
using SYPP.Model.DTO.Calendar;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ApplicationVM
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationViewModel()
        {

        }
        public async Task LoadData()
        {
            try
            {
                List<Task> Tasks = new List<Task>();
                Tasks.Add(PopulateCategories());
                Tasks.Add(PopulateWeeklySchedule());
                Tasks.Add(PopulateApplications());
                await Task.WhenAll(Tasks);
                //await PopulateWeeklySchedule();
                //await PopulateCategories();
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
    

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task UpdateApplicationFavoriteStatus(string applicationID, bool IsFavorite)
        {
            try
            {
                await _socket.Application_IsFavorite_Update_Init(applicationID, IsFavorite);
            }
            catch(Exception ex)
            {

            }
        }
        public async Task PopulateWeeklySchedule()
        {
            try
            {
                if (WeeklyCalendar == null)
                {
                    WeeklyCalendar = new ObservableCollection<Daily_Tasks_DTO>();
                }
                else
                    WeeklyCalendar.Clear();
                int num = 0;
                var day = DateTime.Now.DayOfWeek;
                if (day == DayOfWeek.Monday)
                {
                    num = 0;
                }
                if (day == DayOfWeek.Tuesday)
                {
                    num = -1;
                }
                if (day == DayOfWeek.Wednesday)
                {
                    num = -2;
                }
                if (day == DayOfWeek.Thursday)
                {
                    num = -3;
                }
                if (day == DayOfWeek.Friday)
                {
                    num = -4;
                }
                if (day == DayOfWeek.Saturday)
                {
                    num = -5;
                }
                if (day == DayOfWeek.Sunday)
                {
                    num = -6;
                }
                var time = DateTime.Now.AddDays(num);
                var end = time.AddDays(7);
                for(var current = time; DateTime.Compare(end, current) > 0; current = current.AddDays(1))
                {
                    var date = LocalStorage.Calendar.Where(x => x.Date.Year == current.Year && x.Date.Month == current.Month && x.Date.Day == current.Day).FirstOrDefault();
                    if(date != null)
                    {
                        WeeklyCalendar.Add(date);
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }
        public async Task PopulateCategories()
        {
            try
            {
                if (Category_Filters == null)
                    Category_Filters = new ObservableCollection<Category>();
                else
                    Category_Filters.Clear();
                Category_Filters.Add(new Category
                {
                    SuggestionsOrSeleceted = new List<Category_Suggestion>(),
                    Type = "All",
                    UI_Handler = new Model.DTO.General.Button.Text_Button_DTO
                    {
                        Background = "#C2DBFF",
                        Foreground = "#242931",
                        Background_Hover = "#DBEAFF",
                        Background_Pressed = "#E3EFFF"

                    },
                    Category_PopUp_IsOpen = false
                });
                Category_Filters.Add(new Category
                {
                    SuggestionsOrSeleceted = new List<Category_Suggestion>(),
                    Type = "Starred",
                    UI_Handler = new Model.DTO.General.Button.Text_Button_DTO
                    {
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5"
                    },
                    Category_PopUp_IsOpen = false
                });
                if(LocalStorage.User != null)
                {
                    foreach(var item in LocalStorage.User.Preferences)
                    {
                        item.Category_PopUp_IsOpen = false;
                        if (Category_Filters.Where(x => x.Type == item.Type).Any())
                        {
                            var list = Category_Filters.Where(x => x.Type == item.Type).FirstOrDefault();
                            if(item.SuggestionsOrSeleceted != null)
                            {
                                foreach(var each in item.SuggestionsOrSeleceted)
                                {
                                    if (!list.SuggestionsOrSeleceted.Where(x => x.Content == each.Content).Any())
                                        list.SuggestionsOrSeleceted.Add(each);
                                }
                            }
                            else
                            {
                                item.SuggestionsOrSeleceted = new List<Category_Suggestion>();
                            }
                        }
                        else
                        {
                            item.UI_Handler = new Model.DTO.General.Button.Text_Button_DTO
                            {
                                Background = "#363C46",
                                Foreground = "#C2DBFF",
                                Background_Hover = "#7D8CA8",
                                Background_Pressed = "#94A5C5"
                            };
                            Category_Filters.Add(item);
                        }  
                    }

                    foreach(var item in Category_Filters)
                    {
                        item.UpdateSuggestions();
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }
        public async Task PopulateApplications()
        {
            try
            {
                if(LocalStorage.Applications != null)
                {
                    if(Filter_Selected == "All")
                    {
                        Applications = LocalStorage.Applications;
                    }
                    else
                    {
                        var list = LocalStorage.Applications.Where(x => x.Detail.Categories.Where(y => y.SuggestionsOrSeleceted.Where(a => a.Content.ToLower() == Filter_Selected.ToLower()).Any()).Any()).ToList();
                        Applications = new ObservableCollection<Application>(list);
                    }
                }
                else
                {
                    Applications = new ObservableCollection<Application>();
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
        public Application Application_Selected_Prev { get; set; }
        public Application Application_Selected { get; set; }
        private string _Filter_Selected;
        public string Filter_Selected
        {
            get
            {
                if (String.IsNullOrEmpty(_Filter_Selected))
                    _Filter_Selected = "All";
                return _Filter_Selected; 
            }
            set
            {
                _Filter_Selected = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Daily_Tasks_DTO> WeeklyCalendar { get; set; }
        public ObservableCollection<Category> Category_Filters { get; set; }
        private ObservableCollection<Application> _Applications;
        public ObservableCollection<Application> Applications
        {
            get
            {
                return _Applications;
            }
            set
            {
                _Applications = value;
                OnPropertyChanged();
            }
        }
    }
}
