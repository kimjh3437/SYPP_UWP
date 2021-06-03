using SYPP.Model.DTO.Calendar;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.CalendarVM
{
    public class CalendarViewModel : BaseViewModel
    {
        public CalendarViewModel()
        {

        }
        public async Task LoadData()
        {
            await InitializeModel();
            await PopulateCalendar();
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeModel()
        {
            try
            {
                SelectedTime = DateTime.Now;
                EachMonth = new ObservableCollection<Daily_Tasks_DTO>();
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
                var m_p = month_prev.AddMonths(-1);
                month_prev = m_p;
                var m_n = month_next.AddMonths(1);
                month_next = m_n;

                var month_list_prev = LocalStorage.Calendar.Where(x => x.Date.Month == month_prev.Month && x.Date.Year == month_prev.Year)?.ToList()?.OrderByDescending(x => x.Date)?.ToList();
                var month_list_next = LocalStorage.Calendar.Where(x => x.Date.Month == month_next.Month && x.Date.Year == month_next.Year)?.ToList()?.OrderBy(x => x.Date)?.ToList();
                var month_list = LocalStorage.Calendar.Where(x => x.Date.Month == SelectedTime.Month && x.Date.Year == SelectedTime.Year)?.ToList()?.OrderBy(x => x.Date)?.ToList();

                EachMonth.Clear();

                var date = new DateTime(SelectedTime.Year, SelectedTime.Month, 1); //selected month and year 
                var daysNum = DateTime.DaysInMonth(SelectedTime.Year, SelectedTime.Month); //numer of days in a month
                var startDay = (int)date.DayOfWeek; //starting day ex)monday, tuesday 
                var numOfNext = 35 - daysNum - startDay; //number of days next month
                if (startDay != 0)
                {
                    for (var x = startDay; x > 0; x--)
                    {
                        month_list_prev[x].Foreground = "#6FFFFFFF";
                        EachMonth.Add(month_list_prev[x]);
                    }
                }
                for (var x = 0; x < daysNum; x++)
                {
                    month_list[x].Foreground = "White";
                    EachMonth.Add(month_list[x]);
                }
                if (numOfNext != 0)
                {
                    for (var x = 0; x < numOfNext; x++)
                    {
                        month_list_next[x].Foreground = "#6FFFFFFF";
                        EachMonth.Add(month_list_next[x]);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task RestoreCalendarToday()
        {
            var newTime = DateTime.Now;
            SelectedTime = newTime;
            PopulateCalendar();
        }
        public async Task GoOverNextMonth()
        {
            var newTime = SelectedTime.AddMonths(1);
            SelectedTime = newTime;
            PopulateCalendar();
        }
        public async Task GoOverPrevMonth()
        {
            var newTime = SelectedTime.AddMonths(-1);
            SelectedTime = newTime;
            PopulateCalendar();
        }

        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________
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

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Daily_Tasks_DTO> EachMonth { get; set; }
    }
}
