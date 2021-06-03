using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.Model.DB.Components.Checklists
{
    public class Checklist_Option : BaseModel.BaseModel
    {
        public string checkOptionID { get; set; }
        public string checklistID { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }

        //___________________________________________________________________________________
        //
        // UI Controls - Below
        //___________________________________________________________________________________
        public Visibility _Check_Visibility;
        public Visibility Check_Visibility
        {
            get
            {
                if (this.IsChecked)
                    _Check_Visibility = Visibility.Visible;
                else
                {
                    _Check_Visibility = Visibility.Collapsed;
                }
                return _Check_Visibility;

            }
            set
            {
                _Check_Visibility = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // UI Handlers - Below
        //___________________________________________________________________________________
        public void UpdateCheckVisibility()
        {
            OnPropertyChanged("Check_Visibility");
        }
    }
}
