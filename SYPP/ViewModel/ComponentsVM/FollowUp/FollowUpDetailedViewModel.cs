using SYPP.Model.DTO.General.Button;
using SYPP.View.Components.UserControl;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ComponentsVM.FollowUp
{
    public class FollowUpDetailedViewModel : BaseViewModel
    {
        public FollowUpDetailedViewModel() 
        {
        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();
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
        public async Task InitializeModels()
        {
            try
            {
                NoteVM = new NoteUserControlViewModel();
                await NoteVM.LoadData();

                if (FollowUp != null && FollowUp.Description != null && FollowUp.Description.Count != 0)
                {
                    NoteVM.Contents = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.Contents.Contents_Sub>(FollowUp.Description);
                }
                else
                {
                    await NoteVM.LoadInitElementContents();
                }
                if (FollowUp != null && FollowUp.Files != null && FollowUp.Files.Count != 0)
                {
                    NoteVM.Files = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.File.File>(FollowUp.Files);
                }

                if (CreatingNewFollowUp)
                {
                    SelectedTime = DateTime.UtcNow;
                    FollowUp = new Model.DB.Components.FollowUp.FollowUp
                    {
                        Description = new List<Model.DB.Components.Contents.Contents_Sub>
                        {

                        },
                        Detail = new Model.DB.Components.FollowUp.FollowUp_Detail
                        {
                            Personnel = new Model.DB.Components.Contacts.Contact_Detail
                            {
                                applicationID = applicationID,
                                Firstname = "",
                                Lastname = ""
                            }
                        }
                    };
                }
                else
                {
                    SelectedTime = FollowUp.Detail.Time;
                    NoteVM.Contents = new ObservableCollection<Model.DB.Components.Contents.Contents_Sub>(FollowUp.Description);
                    NoteVM.Files = new ObservableCollection<Model.DB.Components.File.File>(FollowUp.Files);
                }
                
                EachMonth = new ObservableCollection<Text_Button_DTO>();
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
        public async Task SaveFollowUp()
        {
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (CreatingNewFollowUp)
                    {

                        FollowUp.Description = NoteVM.Contents.ToList();
                        FollowUp.Files = NoteVM.Files.ToList();
                        FollowUp.Detail.applicationID = applicationID;
                        FollowUp.Detail.Time = SelectedTime;
                        var output = await _company.CreateCompanyFollowUp(FollowUp);
                        if (output != null)
                        {
                            await _socket.Company_FollowUps_Update_Init(companyID, output.followUpID);
                        }
                    }
                    else
                    {
                        FollowUp.Description = NoteVM.Contents.ToList();
                        FollowUp.Files = NoteVM.Files.ToList();
                        FollowUp.Detail.applicationID = applicationID;
                        var output = await _company.UpdateCompanyFollowUp(FollowUp);
                        if (output != null)
                        {
                            await _socket.Company_FollowUps_Update_Init(companyID, output.followUpID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (CreatingNewFollowUp)
                    {

                        FollowUp.Description = NoteVM.Contents.ToList();
                        FollowUp.Files = NoteVM.Files.ToList();
                        FollowUp.Detail.applicationID = applicationID;
                        FollowUp.Detail.Time = SelectedTime;
                        var output = await _applicaiton.CreateApplicationFollowUp(FollowUp);
                        if (output != null)
                        {
                            await _socket.Application_FollowUps_Update_Init(applicationID, output.followUpID);
                        }
                    }
                    else
                    {
                        FollowUp.Description = NoteVM.Contents.ToList();
                        FollowUp.Files = NoteVM.Files.ToList();
                        FollowUp.Detail.applicationID = applicationID;
                        var output = await _applicaiton.UpdateApplicationFollowUp(FollowUp);
                        if (output != null)
                        {
                            await _socket.Application_FollowUps_Update_Init(applicationID, output.followUpID);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteFollowUp()
        {
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (!CreatingNewFollowUp)
                    {
                        var output = await _company.DeleteCompanyFollowUp(companyID, FollowUp.followUpID);
                        if (output)
                        {
                            await _socket.Company_FollowUps_Update_Init(companyID, FollowUp.followUpID);
                        }
                    }
                    else
                    {

                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (!CreatingNewFollowUp)
                    {
                        var output = await _applicaiton.DeleteApplicationFollowUp(applicationID, FollowUp.followUpID);
                        if (output)
                        {
                            await _socket.Application_FollowUps_Delete_Init(applicationID, FollowUp.followUpID);
                        }
                    }
                    else
                    {

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
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public bool CreatingNewFollowUp { get; set; }
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
        public NoteUserControlViewModel NoteVM { get; set; }
        public SYPP.Model.DB.Components.FollowUp.FollowUp FollowUp { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> EachMonth { get; set; }
    }
}
