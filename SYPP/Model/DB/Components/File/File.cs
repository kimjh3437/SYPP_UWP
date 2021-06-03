using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace SYPP.Model.DB.Components.File
{
    public class File : BaseModel.BaseModel
    {
        public string fileID { get; set; }
        public string uID { get; set; }
        public DateTime UploadTime { get; set; }
        public byte[] Contents { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public void UpdateCheckUI()
        {
            OnPropertyChanged("CheckMark_Visibility");
        }

        //___________________________________________________________________________________
        //
        // UI Handlers - Below
        //___________________________________________________________________________________
        private bool _Preview_IsOpen;
        public bool Preview_IsOpen
        {
            get
            {
                return _Preview_IsOpen;
            }
            set
            {
                _Preview_IsOpen = value;
                OnPropertyChanged();
            }
        }
        private Visibility _CheckMark_Visibility;
        public Visibility CheckMark_Visibility
        {
            get
            {
                if (IsChecked)
                {
                    _CheckMark_Visibility = Visibility.Visible;
                }
                else
                {
                    _CheckMark_Visibility = Visibility.Collapsed;
                }
                return _CheckMark_Visibility;
            }
            set
            {
                _CheckMark_Visibility = value;
                OnPropertyChanged();
            }
        }
        private BitmapImage _ImageSource;
        public BitmapImage ImageSource
        {
            get
            {
                return _ImageSource;
            }
            set
            {
                _ImageSource = value;
                OnPropertyChanged();
            }
        }
    }
}
