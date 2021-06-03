using SYPP.Model.DB;
using SYPP.Model.DB.Components.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DTO.Calendar
{
    public class Calendar_Event_DTO : BaseModel.BaseModel
    {
        public string applicationID { get; set; }
        public string calendarEventID { get; set; }
        public string TaskType { get; set; } // Specifies the type of task ex)events, behavioral, tech interview, challenge, etc // "Task", "Contact", "Status", "Event"
        public MidTask Task { get; set; }
        public Application_Detail Detail { get; set; }
        private string _Status_Icon_Source;
        public string Status_Icon_Source
        {
            get
            {
                if (this.Task.Status)
                {
                    if (this.Task.IsFavorite)
                    {
                        _Status_Icon_Source = "/Assets/Components/Stars/Star_Green_Filled_Icon.svg";
                    }
                    else
                    {
                        _Status_Icon_Source = "/Assets/Components/Stars/Star_Green_Unfilled_Icon.svg";
                    }
                }
                else
                {
                    if (this.Task.IsFavorite)
                    {
                        _Status_Icon_Source = "/Assets/Components/Stars/Star_Yellow_Filled_Icon.svg";
                    }
                    else
                    {
                        _Status_Icon_Source = "/Assets/Components/Stars/Star_Yellow_Unfilled_Icon.svg";
                    }
                }
                return _Status_Icon_Source;
                    
            }
            set
            {
                _Status_Icon_Source = value;
                OnPropertyChanged();
            }
        }
        private string _StatusColor;
        public string StatusColor
        {
            get
            {
                if (this.Task.Status != null)
                {
                    if (this.Task.Status)
                        _StatusColor = "#94CE4B";
                    else
                        _StatusColor = "#FFD600";
                }
                else
                    _StatusColor = "Transparent";
                return _StatusColor;
            }
            set
            {
                _StatusColor = value;
                OnPropertyChanged();
            }
        }

        public void UpdateUI()
        {
            OnPropertyChanged("Status_Icon_Source");
            OnPropertyChanged("StatusColor");
        }
    }
}
