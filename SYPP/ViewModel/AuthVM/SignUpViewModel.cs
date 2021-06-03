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
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
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
                Firstname_Error_Message = "";
                Lastname_Error_Message = "";
                Email_Error_Message = "";
                Password_Error_Message = "";
                Confirm_Password_Message = "";

                Firstname_Borderline = "Transparent";
                Lastname_Borderline = "Transparent";
                Email_Borderline = "Transparent";
                Password_Borderline = "Transparent";
                ConfirmPassword_Borderline = "Transparent";
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task ResetError()
        {
            Firstname_Error_Message = "";
            Lastname_Error_Message = "";
            Email_Error_Message = "";
            Password_Error_Message = "";
            Confirm_Password_Message = "";
        }
        public async Task<User> SignUp()
        {
            if (Firstname == null)
            {
                Firstname_Error_Message = "Required";
                if (Lastname == null)
                {
                    Lastname_Error_Message = "Required";
                    if (Email == null)
                    {
                        Email_Error_Message = "Required";
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                        }
                    }
                    return null;
                }
                else
                {
                    if (Email == null)
                    {
                        Email_Error_Message = "Required";
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                            return null;
                        }
                    }
                    else
                    {
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                            return null;
                        }
                    }
                }
            }
            else
            {
                if (Lastname == null)
                {
                    Lastname_Error_Message = "Required";
                    if (Email == null)
                    {
                        Email_Error_Message = "Required";
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                        }
                    }
                    else
                    {
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                        }
                        return null;
                    }
                    return null;
                }
                else
                {
                    if (Email == null)
                    {
                        Email_Error_Message = "Required";
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                            return null;
                        }
                        return null;
                    }
                    else
                    {
                        if (Password == null)
                        {
                            Password_Error_Message = "Password should be at least 7 characters";
                            return null;
                        }
                    }
                }
            }
            if (Password != ConfirmPassword)
            {
                Confirm_Password_Message = "Confirm Password does not match password";
                ConfirmPassword = "";
                return null;
            }
            if (Email != null)
            {
                User_Register_DTO register = new User_Register_DTO
                {
                    Email = Email,
                    Password = Password,
                    Firstname = Firstname,
                    Lastname = Lastname
                };
                User user = await _auth.Register(register);
                if (user != null)
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
        private string _Firstname, _Lastname, _Email, _Password, _ConfirmPassword;
        private string _Firstname_Borderline, _Lastname_Borderline, _Email_Borderline, _Password_Borderline, _ConfirmPassword_Borderline;
        private string _Firstname_Error_Message, _Lastname_Error_Message, _Email_Error_Message, _Password_Error_Message, _Confirm_Password_Message;
        public string Firstname_Error_Message
        {
            get
            {
                return _Firstname_Error_Message;
            }
            set
            {
                _Firstname_Error_Message = value;
                OnPropertyChanged();
            }
        }
        public string Lastname_Error_Message
        {
            get
            {
                return _Lastname_Error_Message;
            }
            set
            {
                _Lastname_Error_Message = value;
                OnPropertyChanged();
            }
        }
        public string Email_Error_Message
        {
            get
            {
                return _Email_Error_Message;
            }
            set
            {
                _Email_Error_Message = value;
                OnPropertyChanged();
            }
        }
        public string Password_Error_Message
        {
            get
            {
                return _Password_Error_Message;
            }
            set
            {
                _Password_Error_Message = value;
                OnPropertyChanged();
            }
        }
        public string Confirm_Password_Message
        {
            get
            {
                return _Confirm_Password_Message;
            }
            set
            {
                _Confirm_Password_Message = value;
                OnPropertyChanged();
            }
        }
        public string Firstname_Borderline
        {
            get
            {
                return _Firstname_Borderline;
            }
            set
            {
                _Firstname_Borderline = value;
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
        public string ConfirmPassword_Borderline
        {
            get
            {
                return _ConfirmPassword_Borderline;
            }
            set
            {
                _ConfirmPassword_Borderline = value;
                OnPropertyChanged();
            }
        }
        public string Lastname_Borderline
        {
            get
            {
                return _Lastname_Borderline;
            }
            set
            {
                _Lastname_Borderline = value;
                OnPropertyChanged();
            }
        }
        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                _Firstname = value;
                OnPropertyChanged();
            }
        }
        public string Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                _Lastname = value;
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
        public string ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
            }
        }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
    }
}
