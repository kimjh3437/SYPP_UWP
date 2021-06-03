using SYPP.Model.DB.Components.Contents;
using SYPP.Model.DTO.General.Button;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Contacts
{
    public class Contact : BaseModel.BaseModel
    {
        public string contactID { get; set; }
        public Contact_Detail Detail { get; set; }
        //public List<Contact_Type> Contents { get; set; }  
        public Contact_Email Email { get; set; }
        public Contact_Phone Phone { get; set; }
        public List<Contents_Sub> Convo { get; set; }
        public List<SYPP.Model.DB.Components.File.File> Files { get; set; }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> Contacts { get; set; }
        private Text_Button_DTO _Contacts_Selected;
        public Text_Button_DTO Contacts_Selected
        {
            get
            {
                return _Contacts_Selected;
            }
            set
            {
                _Contacts_Selected = value;
                OnPropertyChanged();
            }
        }
    }
}
