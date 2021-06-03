using SYPP.Model.DB.Components.Categories;
using SYPP.Model.DTO.Calendar;
using SYPP.Model.DTO.General.Button;
using SYPP.Model.DTO.General.Components;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ApplicationVM.NewAppsVM
{
    public class CreateApplicationViewModel : BaseViewModel
    {
        public CreateApplicationViewModel()
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

                    },
                    new Model.DTO.General.Button.Text_Button_DTO
                    {
                        Text = "3",
                        Background = "#363C46",
                        Foreground = "#242931",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5"

                    }
                };
            }
            catch(Exception ex)
            {

            }
        }
        public async Task InitModels()
        {
            try
            {
                CustomCategories = new ObservableCollection<Category_DTO>();
                CreatedLocations = new ObservableCollection<Text_Button_DTO>();
                CreatedRoles = new ObservableCollection<Text_Button_DTO>();
                SelectedTime = DateTime.Now; 
                EachMonth = new ObservableCollection<Text_Button_DTO>();
                Categories = new ObservableCollection<Category>();
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
                    if(SelectedTime.Year == DateTime.Today.Year && SelectedTime.Month == DateTime.Today.Month && x == DateTime.Today.Day)
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
        public async Task CreateApplication()
        {
            try
            {
                if(CreatedRoles != null && CreatedRoles.Count != 0)
                {
                    var list = new List<Category_Suggestion>();
                    foreach(var item in CreatedRoles)
                    {
                        list.Add(new Category_Suggestion
                        {
                            suggestionID = Guid.NewGuid().ToString(),
                            Content = item.Text
                        });
                    }
                    Categories.Add(new Category
                    {
                        Type = "Role",
                        SuggestionsOrSeleceted = list
                    });
                }
                if (CreatedLocations != null && CreatedLocations.Count != 0)
                {
                    var list = new List<Category_Suggestion>();
                    foreach (var item in CreatedLocations)
                    {
                        list.Add(new Category_Suggestion
                        {
                            suggestionID = Guid.NewGuid().ToString(),
                            Content = item.Text
                        });
                    }
                    Categories.Add(new Category
                    {
                        Type = "Location",
                        SuggestionsOrSeleceted = list
                    });
                }
                if(CustomCategories != null && CustomCategories.Count != 0)
                {
                    foreach(var item in CustomCategories)
                    {
                        var list = new List<Category_Suggestion>();
                        if(Categories.Where(x => x.Type == item.Type).Any())
                        {
                            var category = Categories.Where(x => x.Type == item.Type).FirstOrDefault();
                            foreach(var op in item.Options)
                            {
                                category.SuggestionsOrSeleceted.Add(new Category_Suggestion
                                {
                                    Content = op.Text,
                                    suggestionID = Guid.NewGuid().ToString()
                                });
                            }
                        }
                        else
                        {
                            Categories.Add(new Category
                            {
                                categoryID = Guid.NewGuid().ToString(),
                                Type = item.Type,
                                SuggestionsOrSeleceted = new List<Category_Suggestion>()
                            });
                        }
                    }
                }

                var app = await _applicaiton.CreateApplication(new Model.DTO.Application.Application_Create_DTO
                {
                    Detail = new Model.DB.Application_Detail 
                    {
                        uID = LocalStorage.User.uID,
                        PositionName = PositionTitle,
                        CompanyName = CompanyName, 
                        Status = new List<Model.DB.Components.Tasks.MidTask> 
                        {
                            new Model.DB.Components.Tasks.MidTask
                            {
                                applicationID = "",
                                Title = "Submission",
                                Time = SelectedTime,
                                Type = "Status",
                                Status = HaveYouApplied,
                                IsFavorite = false,
                                IsVisible = DisplayThisDate,
                            },
                            new Model.DB.Components.Tasks.MidTask
                            {
                                Time = DateTime.UtcNow,
                                Title = "Results",
                                Type = "Status",
                                Status = false,
                                IsVisible = false,
                                IsFavorite = false
                            }
                        },
                        Categories = Categories.ToList(),
                        IsFavorite = false
                    }
                });
                if(app != null)
                {
                    await _socket.Application_Add_Update_Init(app.applicationID);
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
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
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
        public bool HaveYouApplied { get; set; }
        public bool DisplayThisDate { get; set; }


        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> Navigations { get; set; }
        public ObservableCollection<Text_Button_DTO> CreatedRoles { get; set; }
        public ObservableCollection<Text_Button_DTO> CreatedLocations { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Category_DTO> CustomCategories { get; set; }
        public ObservableCollection<Text_Button_DTO> EachMonth { get; set; }
    }
}
