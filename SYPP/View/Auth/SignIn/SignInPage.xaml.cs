using SYPP.View.Auth.SignUp;
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
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SYPP.View.Auth.SignIn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInViewModel MainVM;
        public SignInPage()
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
                MainVM = new SignInViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (SignInViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (SignInViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            await SetSize();
            //Modify objects 
        }
        public async Task SetSize()
        {
            try
            {
                ApplicationView.PreferredLaunchViewSize = new Size(1440, 900);
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            }
            catch(Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var user = await MainVM.SignIn();
            if (user != null)
            {
                var mainVM = new MainBoardViewModel();
                await mainVM.LoadData();
                this.Frame.Navigate(typeof(MainBoard), mainVM, new DrillInNavigationTransitionInfo());
            }
            //var mainVM = new MainBoardViewModel();
            //await mainVM.LoadData();
            //this.Frame.Navigate(typeof(MainBoard), mainVM, new DrillInNavigationTransitionInfo());
        }

        private void Forgot_Password_Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO 
        }

        private void Create_Account_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUpPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Password_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.Password_Error_Text = "";
            MainVM.Email_Error_Text = "";
            var obj = sender as TextBox;
            var text = obj.Text;
            if (text != "")
            {
                MainVM.Password_Borderline = "#80FFE9D6";
                MainVM.Email_Borderline = "Transparent";
            }
        }

        private void Email_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainVM.Password_Error_Text = "";
            MainVM.Email_Error_Text = "";
            var obj = sender as TextBox;
            var text = obj.Text;
            if (text != "")
            {
                MainVM.Password_Borderline = "Transparent";
                MainVM.Email_Borderline = "#80FFE9D6";
            }
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
