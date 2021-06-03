using SYPP.Model.DB.Components.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.Model.DB.Components.Notes
{
    public class Note : BaseModel.BaseModel
    {
        public string noteID { get; set; }
        //  public string applicationID { get; set; }
        public Note_Detail Detail { get; set; }
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
        // Event Handlers - Below
        //___________________________________________________________________________________
        private List<Contents_Sub> _Contents;     
    }
}
