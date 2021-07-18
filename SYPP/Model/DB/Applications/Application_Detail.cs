using SYPP.Model.DB.Components.Categories;
using SYPP.Model.DB.Components.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.Model.DB
{
    public class Application_Detail : BaseModel.BaseModel
    {
        public string applicationID { get; set; }
        public string uID { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string companyID { get; set; }
        public string positionID { get; set; }
        public List<MidTask> Status { get; set; } //this status represent applied and result status static 

        //Title = ApplicationStatus and ResultStatus for Status
        public List<Category> Categories { get; set; }
        public bool IsFavorite { get; set; }

        //___________________________________________________________________________________
        //
        // UI Updates - Below
        //___________________________________________________________________________________
        
        public void UpdateHasAppliedStatus()
        {
            OnPropertyChanged("HasApplied");
            OnPropertyChanged("HasApplied_Background");
        }
        public void UpdateResultStatus()
        {
            OnPropertyChanged("HasResult");
            OnPropertyChanged("HasResult_Background");
        }

        //___________________________________________________________________________________
        //
        // UI Updates - Below
        //___________________________________________________________________________________
        private bool _HasApplied;
        public bool HasApplied
        {
            get
            {
                if(this.Status != null)
                {
                    var hasapplied = this.Status[0];
                    _HasApplied = hasapplied.Status;
                }
                return _HasApplied;
            }
            set
            {
                _HasApplied = value;
                OnPropertyChanged();
            }
        }
        private string _HasApplied_Background;
        public string HasApplied_Background
        {
            get
            {
                if (HasApplied)
                {
                    _HasApplied_Background = "#94CE4B";
                }
                else
                {
                    _HasApplied_Background = "#FFD600";
                }
                return _HasApplied_Background;
            }
            set
            {
                _HasApplied_Background = value;
                OnPropertyChanged();
            }
        }
        private string _HasApplied_Date;
        public string HasApplied_Date
        {
            get
            {
                if (this.Status != null)
                {
                    _HasApplied_Date = Status[0].Time.ToString("MMM d");
                }
                else
                    _HasApplied_Date = "Error";
                return _HasApplied_Date;             
            }
            set
            {
                _HasApplied_Date = value;
                OnPropertyChanged();
            }
        }
        private Visibility _ResultVisibility, _AddResultVisibility;
        public Visibility ResultVisibility
        {
            get
            {
                return _ResultVisibility;
            }
            set
            {
                _ResultVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility AddResultVisibility
        {
            get
            {
                return _AddResultVisibility;
            }
            set
            {
                _AddResultVisibility = value;
                OnPropertyChanged();
            }
        }

        private bool _HasResult;
        public bool HasResult
        {
            get
            {
                if (this.Status.Where(x => x.Title == "Results").Any())
                {
                    var result = this.Status.Where(x => x.Title == "Results").FirstOrDefault();
                    ResultVisibility = Visibility.Visible;
                    AddResultVisibility = Visibility.Collapsed;
                    _HasResult = result.Status;
                }
                else
                {
                    ResultVisibility = Visibility.Collapsed;
                    AddResultVisibility = Visibility.Visible;
                }
                return _HasResult;
            }
            set
            {
                _HasResult = value;
                OnPropertyChanged();
            }
        }
        private string _HasResult_Background, _HasResult_Date;
        public string HasResult_Background
        {
            get
            {
                if (HasResult)
                {
                    _HasResult_Background = "#94CE4B";
                }
                else
                {
                    _HasResult_Background = "#FFD600";
                }
                return _HasResult_Background;
            }
        }
        public string HasResult_Date
        {
            get
            {
                if (this.Status != null)
                {
                    if (Status.Count > 1)
                        _HasResult_Date = Status[1].Time.Date.ToString("MMM d");
                    else
                        _HasResult_Date = "Error";
                }
                else
                    _HasResult_Date = "Error";
                return _HasResult_Date;
            }
            set
            {
                _HasResult_Date = value;
                OnPropertyChanged();
            }
        }
    


    }
}
