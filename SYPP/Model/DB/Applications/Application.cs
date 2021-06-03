using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DB.Components.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB
{
    public class Application : BaseModel.BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string applicationID { get; set; }
        public string uID { get; set; } // userID
        public List<MidTask> Tasks { get; set; }
        public Application_Detail Detail { get; set; }
        public List<Event> Events { get; set; }
        public List<Note> Notes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<FollowUp> FollowUps { get; set; }
        public List<Checklist> Checklists { get; set; }

        //___________________________________________________________________________________
        //
        // UI Updates - Below
        //___________________________________________________________________________________
        public void UpdateUI()
        {
            OnPropertyChanged("BorderBrush");
            OnPropertyChanged("Background");
        }
        public void UpdateFavoriteStatus()
        {
            OnPropertyChanged("IsFavorite_IconSource");
        }

        //___________________________________________________________________________________
        //
        // UI Control Models - Below
        //___________________________________________________________________________________
        public bool IsSelected { get; set; }
        
        private string _BorderBrush, _Background;
        public string BorderBrush
        {
            get
            {
                if (IsSelected)
                {
                    _BorderBrush = "#C2DBFF";
                }
                else
                {
                    _BorderBrush = "transparent";
                }
                return _BorderBrush;
            }
            set
            {
                _BorderBrush = value;
                OnPropertyChanged();
            }
        }
        public string Background
        {
            get
            {
                if (IsSelected)
                {
                    _Background = "#339CC1F9";
                }
                else
                {
                    _Background = "transparent";
                }
                return _Background;
            }
            set
            {
                _Background = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // UI Updates - Below
        //___________________________________________________________________________________
        private string _IsFavorite_IconSource;
        public string IsFavorite_IconSource
        {
            get
            {
                if (_IsFavorite_IconSource == null)
                {
                    _IsFavorite_IconSource = "/Assets/Components/Stars/Star_Unfilled_Icon.svg";
                }
                if (Detail.IsFavorite)
                {
                    _IsFavorite_IconSource = "/Assets/Components/Stars/Star_Filled_Icon.svg";
                }
                else
                {
                    _IsFavorite_IconSource = "/Assets/Components/Stars/Star_Unfilled_Icon.svg";
                }
                return _IsFavorite_IconSource;
            }
            set
            {
                _IsFavorite_IconSource = value;
                OnPropertyChanged();
            }
        }

    }
}
