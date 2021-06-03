using SYPP.Model.DTO.General.Button;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DTO.General.Components
{
    public class Category_DTO : BaseModel.BaseModel
    {
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Text_Button_DTO> Options { get; set; }


        //___________________________________________________________________________________
        //
        // UI Handlers - Below
        //___________________________________________________________________________________
        private string _Placeholder_Text, _Type;
        public string Placeholder_Text
        {
            get
            {
                if (String.IsNullOrEmpty(_Placeholder_Text))
                {
                    _Placeholder_Text = "Type to create new category";
                }
                return _Placeholder_Text;
            }
            set
            {
                _Placeholder_Text = value;
                OnPropertyChanged();
            }
        }
    }
}
