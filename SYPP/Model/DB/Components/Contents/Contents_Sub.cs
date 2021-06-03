using SYPP.Model.DB.Components.Texts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.Model.DB.Components.Contents
{
    public class Contents_Sub : BaseModel.BaseModel
    {
        public string noteContentsID { get; set; }
        public string Content
        {
            get
            {
                if (!String.IsNullOrEmpty(_Content))
                {
                    //if(!_Header.Contains("-"))
                    //    _Header = "- " + _Header;
                }
                return _Content;
            }
            set 
            {
                _Content = value;
                OnPropertyChanged();

            }
        }
        //public List<Contents_Text> Contents { get; set; }
        public int MarginType // Type 0, 1, 2, 3, 4,
        {
            get
            {
                return _MarginType;
            }
            set
            {
                _MarginType = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // UI Control - Below
        //___________________________________________________________________________________
        private int _MarginType;
        private string _Content;
        private Thickness _Margin, _Margin_Collapsed;
        private Visibility _Visibility, _Bullet_Visibility;
        public Visibility Visibility
        {
            get
            {
                if (!String.IsNullOrEmpty(this.Content))
                {
                    _Visibility = Visibility.Visible;
                }
                else
                {
                    _Visibility = Visibility.Collapsed;
                }
                return _Visibility;
            }
            set
            {
                _Visibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility Bullet_Visibility
        {
            get
            {
                if (this.MarginType == 0)
                {
                    _Bullet_Visibility = Visibility.Collapsed;
                }
                else
                    _Bullet_Visibility = Visibility.Visible;
                return _Bullet_Visibility;
            }
            set
            {
                _Bullet_Visibility = value;
                OnPropertyChanged();
            }
        }
        public Thickness Margin
        {
            get
            {
                if (this.MarginType == 0)
                {
                    _Margin = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    _Margin = new Thickness(MarginType * 10, 0, 0, 0);
                }
                return _Margin;
            }
            set
            {
                _Margin = value;
                OnPropertyChanged();
            }
        }
        public Thickness Margin_Collapsed
        {
            get
            {
                if (this.MarginType == 0)
                {
                    _Margin_Collapsed = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    _Margin_Collapsed = new Thickness(MarginType * 2.5, 0, 0, 0);
                }
                return _Margin_Collapsed;
            }
            set
            {
                _Margin_Collapsed = value;
                OnPropertyChanged();
            }
        }


        //___________________________________________________________________________________
        //
        // UI Event Hnadler - Below
        //___________________________________________________________________________________
        public void UpdateBulletVisibility()
        {
            OnPropertyChanged("Bullet_Visibility");
        }
        public void UpdateMargin()
        {
            OnPropertyChanged("Margin");
        }
    }
}
