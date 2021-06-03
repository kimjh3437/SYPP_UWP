using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Tasks
{
    public class MidTask : BaseModel.BaseModel
    {
        public string midTaskID { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsVisible { get; set; }
        public string companyID { get; set; }
        public string applicationID { get; set; }

        //___________________________________________________________________________________
        //
        // UI Update Models - Below
        //___________________________________________________________________________________
        public void UpdateStatus()
        {
            OnPropertyChanged("Status_Background");
        }

        //___________________________________________________________________________________
        //
        // UI Handler Models - Below
        //___________________________________________________________________________________
        private string _Status_Background;
        public string Status_Background
        {
            get
            {
                if (this.Status)
                {
                    _Status_Background = "#94CE4B";
                }
                else
                {
                    _Status_Background = "#FFD600";                   
                }
                return _Status_Background;
            }
            set
            {
                _Status_Background = value;
                OnPropertyChanged();
            }
        }
        private string _Task_Date;
        public string Task_Date
        {
            get
            {
                _Task_Date = Time.ToString("MMM d");
                return _Task_Date;
            }
            set
            {
                _Task_Date = value;
                OnPropertyChanged();
            }
        }
    }
}
