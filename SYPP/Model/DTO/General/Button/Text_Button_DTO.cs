using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.Model.DTO.General.Button
{
    public class Text_Button_DTO : BaseModel.BaseModel
    {
        public DateTime DateTime { get; set; }
        public string correspondenceID { get; set; }
        public string Text { get; set; }
        public int Icon_Height { get; set; }
        public int Icon_Width { get; set; }
        private string _IconSource;
        public string IconSource
        {
            get
            {
                return _IconSource;
            }
            set
            {
                _IconSource = value;
                OnPropertyChanged();
            }
        }
        private string _Background;
        public string Background
        {
            get
            {
                return _Background;
            }
            set
            {
                _Background = value;
                OnPropertyChanged();
            }
        }
        private string _Foreground;
        public string Foreground
        {
            get
            {
                return _Foreground;
            }
            set
            {
                _Foreground = value;
                OnPropertyChanged();
            }
        }
        private string _Background_Hover;
        public string Background_Hover
        {
            get
            {
                return _Background_Hover;
            }
            set
            {
                _Background_Hover = value;
                OnPropertyChanged();
            }
        }
        private string _Background_Pressed;
        public string Background_Pressed
        {
            get
            {
                return _Background_Pressed;
            }
            set
            {
                _Background_Pressed = value;
                OnPropertyChanged();
            }
        }
        public Visibility Visibility { get; set; }
        private bool _PopUp_IsOpen;
        public bool PopUp_IsOpen
        {
            get
            {
                return _PopUp_IsOpen;
            }
            set
            {
                _PopUp_IsOpen = value;
                OnPropertyChanged();
            }
        }
        public string Type { get; set; }
    }
}
