using SYPP.Model.DB.Companies;
using SYPP.Model.DTO.Calendar;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.CompanyVM
{
    public class CompanyViewModel : BaseViewModel 
    {
        public CompanyViewModel()
        {

        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();

                List<Task> Tasks = new List<Task>();

                Tasks.Add(PopulateCompanies());
                Tasks.Add(PopulateWeeklySchedule());

                await Task.WhenAll(Tasks);
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
                Companies = new ObservableCollection<Company>();
                WeeklyCalendar = new ObservableCollection<Daily_Tasks_DTO>();
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task PopulateCompanies()
        {
            try
            {
                if (LocalStorage.Companies != null)
                {
                    if (Filter_Selected == "Alphabetical")
                    {
                        var list = LocalStorage.Companies.OrderBy(x => x.Detail.CompanyName).ToList();
                        Companies = new ObservableCollection<Company>(list);
                    }
                    if(false) //TODO
                    {
                        Companies = new ObservableCollection<Company>(LocalStorage.Companies);
                    }
                }
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
        public async Task CreateCopmany()
        {
            try
            {
                if (!string.IsNullOrEmpty(CompanyName))
                {
                    var output = await _company.CreateCompany(new Company_Detail
                    {
                        uID = LocalStorage.User.uID,
                        CompanyName = CompanyName,
                        IsFavorite = false,
                        SubmittedTime = DateTime.UtcNow
                    });
                    if(output != null)
                    {
                        await _socket.Company_Add_Update_Init(output.Detail.companyID);
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
        public Company Company_Selected { get; set; }
        public Company Company_Selected_Prev { get; set; }
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
        public string CompanyName { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Daily_Tasks_DTO> WeeklyCalendar { get; set; }
    }
}
