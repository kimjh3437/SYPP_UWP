using SYPP.Model.DB.Template;
using SYPP.Model.DTO.Calendar;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.TemplateVM
{
    public class TemplateViewModel : BaseViewModel
    {
        public TemplateViewModel()
        {
           
        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();
                await PopulateWeeklySchedule();
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
                Filter_Selected = "Alphabetical";
                if(LocalStorage.Templates != null)
                    Templates = LocalStorage.Templates;
                else
                {
                    Templates = new ObservableCollection<Template>();
                }
                WeeklyCalendar = new ObservableCollection<Daily_Tasks_DTO>();


                Templates.Add(new Template
                {
                    templateID = "!23",
                    Detail = new Template_Detail
                    {
                        IsFavorite = true,
                        Title = "Example Post",
                        uID = LocalStorage.User.uID,
                        DateModified = DateTime.Now,
                        templateID = "!23"
                    },
                    Content = new Template_Content
                    {
                        Content = "This is an example content from mock data creation",
                        templateID = "!23"
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
                for (var current = time; DateTime.Compare(end, current) > 0; current = current.AddDays(1))
                {
                    var date = LocalStorage.Calendar.Where(x => x.Date.Year == current.Year && x.Date.Month == current.Month && x.Date.Day == current.Day).FirstOrDefault();
                    if (date != null)
                    {
                        WeeklyCalendar.Add(date);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________
        private string _Filter_Selected;
        public string Filter_Selected
        {
            get
            {
                return _Filter_Selected;
            }
            set
            {
                _Filter_Selected = value;
                OnPropertyChanged();
            }
        }
        public Template Template_Selected { get; set; }
        public Template Template_Selected_Prev { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Daily_Tasks_DTO> WeeklyCalendar { get; set; }
        public ObservableCollection<Template> Templates { get; set; }
    }
}
