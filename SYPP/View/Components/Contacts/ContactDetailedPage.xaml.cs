using SYPP.Utilities.Storage;
using SYPP.View.Application;
using SYPP.View.Application.Detail;
using SYPP.View.Company;
using SYPP.View.Company.Detail;
using SYPP.View.Components.UserControls;
using SYPP.View.Main;
using SYPP.ViewModel.ComponentsVM.Contact;
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

namespace SYPP.View.Components.Contacts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactDetailedPage : Page
    {
        public ContactDetailedViewModel MainVM;
        public ContactDetailedPage()
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
                MainVM = new ContactDetailedViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (ContactDetailedViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ContactDetailedViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            await SetUpNote();
            //Modify objects 
        }
        public async Task SetUpNote()
        {
            try
            {
                var Note = new NotesUserControl();
                Note.DataContext = MainVM.NoteVM;
                await Note.InitializeDataContext();
                UserControl.Content = Note;

            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Email Related Handlers - Below
        //___________________________________________________________________________________

        private void Email_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Contact.Email.Email = obj.Text;
            }
        }

        //___________________________________________________________________________________
        //
        // Phone Number Related Handlers - Below
        //___________________________________________________________________________________

        private void PhoneNumber_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Contact.Phone.PhoneNumber = obj.Text;
            }
        }

        //___________________________________________________________________________________
        //
        // Header (Name and Title) Related Handlers - Below
        //___________________________________________________________________________________

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Contact.Detail.Firstname = obj.Text;
            }
        }

        private void Title_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Contact.Detail.Title = obj.Text;
            }
        }

        //___________________________________________________________________________________
        //
        // Header (Name and Title) Related Handlers - Below
        //___________________________________________________________________________________
        private async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.DeleteContact();
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                if (LocalStorage.Coordinate == 20)
                {
                    var app = main.Main_Contents_Frame.Content as ApplicationsPage;
                    var app_detailed = app.Application_Detail_Frame.Content as ApplicationDetailPage;
                    app_detailed.Application_Components_Popup.IsOpen = false;
                }
                if (LocalStorage.Coordinate == 30)
                {
                    var company = main.Main_Contents_Frame.Content as CompaniesPage;
                    var app_detailed = company.Company_Detail_Frame.Content as CompanyDetailedPage;
                    app_detailed.Company_Components_Popup.IsOpen = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.SaveContact();
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                if (LocalStorage.Coordinate == 20)
                {
                    var app = main.Main_Contents_Frame.Content as ApplicationsPage;
                    var app_detailed = app.Application_Detail_Frame.Content as ApplicationDetailPage;
                    app_detailed.Application_Components_Popup.IsOpen = false;
                }
                if (LocalStorage.Coordinate == 30)
                {
                    var company = main.Main_Contents_Frame.Content as CompaniesPage;
                    var app_detailed = company.Company_Detail_Frame.Content as CompanyDetailedPage;
                    app_detailed.Company_Components_Popup.IsOpen = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                if (LocalStorage.Coordinate == 20)
                {
                    var app = main.Main_Contents_Frame.Content as ApplicationsPage;
                    var app_detailed = app.Application_Detail_Frame.Content as ApplicationDetailPage;
                    app_detailed.Application_Components_Popup.IsOpen = false;
                }
                if (LocalStorage.Coordinate == 30)
                {
                    var company = main.Main_Contents_Frame.Content as CompaniesPage;
                    var app_detailed = company.Company_Detail_Frame.Content as CompanyDetailedPage;
                    app_detailed.Company_Components_Popup.IsOpen = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
