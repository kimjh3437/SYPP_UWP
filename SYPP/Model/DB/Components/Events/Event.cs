using SYPP.Model.DB.Components.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Events
{
    public class Event : BaseModel.BaseModel
    {
        public string eventID { get; set; }
        public Event_Detail Detail { get; set; }
        public List<Contents_Sub> Contents
        {
            get
            {
                return _Contents;
            }
            set
            {
                _Contents = value;
                OnPropertyChanged();
            }
        }
        public List<SYPP.Model.DB.Components.File.File> Files { get; set; }
        //___________________________________________________________________________________
        //
        // UI Event Handlers - Below
        //___________________________________________________________________________________
        public void ContentsUpdate()
        {
            OnPropertyChanged("Contents");
        }

        //___________________________________________________________________________________
        //
        // Observable Contents - Below
        //___________________________________________________________________________________
        private List<Contents_Sub> _Contents;
    }
}
