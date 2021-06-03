using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SYPP.Model.DTO.General.Button;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Categories
{
    public class Category : BaseModel.BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string categoryID { get; set; }
        public string Type { get; set; }
        //public List<string> SuggestionsOrSeleceted { get; set; } // Deprecated 
        public List<Category_Suggestion> SuggestionsOrSeleceted { get; set; }

        //___________________________________________________________________________________
        //
        // UI Handlers - Below
        //___________________________________________________________________________________
        public Text_Button_DTO UI_Handler { get; set; }
        private bool _Category_PopUp_IsOpen;
        public bool Category_PopUp_IsOpen
        {
            get
            {
                return _Category_PopUp_IsOpen;
            }
            set
            {
                _Category_PopUp_IsOpen = value;
                OnPropertyChanged();
            }
        }
        public void UpdateSuggestions()
        {
            Suggestions_Observable.Clear();
            foreach(var item in SuggestionsOrSeleceted)
            {
                Suggestions_Observable.Add(item);
            }
        }

        //___________________________________________________________________________________
        //
        // UI Observable Collection - Below
        //___________________________________________________________________________________
        private ObservableCollection<Category_Suggestion> _Suggests_Observable;
        public ObservableCollection<Category_Suggestion> Suggestions_Observable
        {
            get
            {
                if(_Suggests_Observable == null)
                {
                    if (this.SuggestionsOrSeleceted != null)
                        _Suggests_Observable = new ObservableCollection<Category_Suggestion>(this.SuggestionsOrSeleceted);
                    else
                        _Suggests_Observable = new ObservableCollection<Category_Suggestion>();
                }
                return _Suggests_Observable;
            }
            set
            {
                _Suggests_Observable = value;
                OnPropertyChanged();
            }
        }
    }
}
