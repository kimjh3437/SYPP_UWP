using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DTO.Calendar
{
    public class Daily_Tasks_DTO : BaseModel.BaseModel
    {
        private string _BorderColor, _Day, _Month, _Foreground;
        public DateTime Date { get; set; }
        public ObservableCollection<Calendar_Event_DTO> Events { get; set; }
        public string Foreground
        {
            get
            {
                return _Foreground;
            }
            set
            {
                _Foreground = value;
                OnPropertyChanged();
            }
        }
        public string Month
        {
            get
            {
                if (this.Date != null)
                {
                    _Month = this.Date.ToString("M");
                }
                return _Month;
            }
            set
            {
                _Month = value;
                OnPropertyChanged();
            }
        }
        public string Day
        {
            get
            {
                if (this.Date != null)
                {
                    _Day = this.Date.Day.ToString();
                }
                return _Day;
            }
            set
            {
                _Day = value;
                OnPropertyChanged();
            }
        }  
        public string Day_String
        {
            get
            {
                return Date.ToString("ddd (MMM dd)");
            }
        }
        public string BorderColor
        {
            get
            {
                var today = DateTime.Now;
                if (this.Date.Month == today.Month && this.Date.Day == today.Day)
                    return "#DEFFFFFF";
                if (this.Events.Count != 0)
                {
                    var count = 0;
                    var status = true;
                    foreach (var app in this.Events)
                    {
                        if (app.Task.IsFavorite)
                        {
                            if (!app.Task.Status)
                            {
                                status = false;
                            }
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        _BorderColor = "#242931";
                    }
                    else if (status)
                        _BorderColor = "#DE94CE4B";
                    else
                    {
                        _BorderColor = "#DEFFD600";
                    }
                }
                else
                {
                    _BorderColor = "#242931";
                }
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                OnPropertyChanged("BorderColor");
            }
        }

        //___________________________________________________________________________________
        //
        // UI Update Controller Handlers - Below
        //___________________________________________________________________________________
        public void UpdateBorderColor()
        {
            OnPropertyChanged("BorderColor");
        }
    }
}
