using SYPP.View.Auth.SignIn;
using SYPP.View.Main;
using SYPP.ViewModel.AuthVM;
using SYPP.ViewModel.MainBoardVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SYPP.View.Auth.SignUp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        public SignUpViewModel MainVM;
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeDataContext()
        {
            if (this.DataContext == null)
            {
                MainVM = new SignUpViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (SignUpViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (SignInViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            //Modify objects 
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        private async void Already_Have_Acccount_Button_Click(object sender, RoutedEventArgs e)
        {
            var SignInVM = new SignInViewModel();
            await SignInVM.LoadData();
            this.Frame.Navigate(typeof(SignInPage), SignInVM);
        }

        private async void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            var user = await MainVM.SignUp();
            if (user != null)
            {
                var MainVM = new MainBoardViewModel();
                await MainVM.LoadData();
                this.Frame.Navigate(typeof(MainBoard), MainVM);
            }
            //TODO Implement 
            //Registration
        }

        private void Firstname_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            MainVM.Firstname = obj.Text;

            MainVM.Firstname_Error_Message = "";
            MainVM.Firstname_Borderline = "#CCFFE9D6";
            MainVM.Lastname_Borderline = "Transparent";
            MainVM.Email_Borderline = "Transparent";
            MainVM.Password_Borderline = "Transparent";
            MainVM.ConfirmPassword_Borderline = "Transparent";
        }

        private void Lastname_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            MainVM.Lastname = obj.Text;

            MainVM.Lastname_Error_Message = "";
            MainVM.Firstname_Borderline = "#Transparent";
            MainVM.Lastname_Borderline = "#CCFFE9D6";
            MainVM.Email_Borderline = "Transparent";
            MainVM.Password_Borderline = "Transparent";
            MainVM.ConfirmPassword_Borderline = "Transparent";
        }

        private void Email_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            MainVM.Email = obj.Text;

            MainVM.Email_Error_Message = "";
            MainVM.Firstname_Borderline = "#Transparent";
            MainVM.Lastname_Borderline = "Transparent";
            MainVM.Email_Borderline = "#CCFFE9D6";
            MainVM.Password_Borderline = "Transparent";
            MainVM.ConfirmPassword_Borderline = "Transparent";
        }

        private void Password_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            MainVM.Password = obj.Text;

            MainVM.Password_Error_Message = "";
            MainVM.Firstname_Borderline = "#Transparent";
            MainVM.Lastname_Borderline = "Transparent";
            MainVM.Email_Borderline = "Transparent";
            MainVM.Password_Borderline = "#CCFFE9D6";
            MainVM.ConfirmPassword_Borderline = "Transparent";
        }

        private void Confirm_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            MainVM.ConfirmPassword = obj.Text;

            MainVM.Confirm_Password_Message = "";
            MainVM.Firstname_Borderline = "#Transparent";
            MainVM.Lastname_Borderline = "Transparent";
            MainVM.Email_Borderline = "Transparent";
            MainVM.Password_Borderline = "Transparent";
            MainVM.ConfirmPassword_Borderline = "#CCFFE9D6";
        }

        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________


        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
    }
}
