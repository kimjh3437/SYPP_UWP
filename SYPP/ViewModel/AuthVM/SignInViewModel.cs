using SYPP.Model.DB.User;
using SYPP.Model.DTO.Auth;
using SYPP.Utilities.Storage;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SYPP.ViewModel.AuthVM
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel()
        {

        }
        public async Task LoadData()
        {
            try
            {
                await InitSettings();

            }
            catch(Exception ex)
            {
                Console.Write($"<MethodName> : {ex}");
            }
        } 

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitSettings()
        {
            try
            {
                Email_Error_Visibility = Visibility.Collapsed;
                Password_Error_Visibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task<User> SignIn()
        {
            if (Email == null)
            {
                Email_Error_Text = "Email cannot be empty";
                return null;
            }
            if (Password == null)
            {
                Password_Error_Text = "Password cannot be empty";
                return null;
            }
            if (Email != null && Password != null)
            {
                Email_Error_Text = "";
                Password_Error_Text = "";
                User_Authenticate_DTO model = new User_Authenticate_DTO
                {
                    Email = Email,
                    Password = Password
                };
                User user = await _auth.Authenticate(model);
                if (user == null)
                {
                    Email_Error_Text = "Invalid Authentication";
                    return null;
                }
                else
                {
                    LocalStorage.User = user;
                }
                return user;
            }
            return null;
        }

        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________
        private string _Email, _Password;
        private string _Email_Error_Text, _Password_Error_Text;
        private Visibility _Email_Error_Visibility, _Password_Error_Visibility;
        private string _Email_Borderline, _Password_Borderline;
        public string Email_Error_Text
        {
            get
            {
                return _Email_Error_Text;
            }
            set
            {
                _Email_Error_Text = value;
                OnPropertyChanged();
            }
        }
        public string Password_Error_Text
        {
            get
            {
                return _Password_Error_Text;
            }
            set
            {
                _Password_Error_Text = value;
                OnPropertyChanged();

            }
        }
        public string Email_Borderline
        {
            get
            {
                return _Email_Borderline;
            }
            set
            {
                _Email_Borderline = value;
                OnPropertyChanged();
            }
        }
        public string Password_Borderline
        {
            get
            {
                return _Password_Borderline;
            }
            set
            {
                _Password_Borderline = value;
                OnPropertyChanged();
            }
        }

        public Visibility Email_Error_Visibility
        {
            get
            {
                return _Email_Error_Visibility;
            }
            set
            {
                _Email_Error_Visibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility Password_Error_Visibility
        {
            get
            {
                return _Password_Error_Visibility;
            }
            set
            {
                _Password_Error_Visibility = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
    }
}
