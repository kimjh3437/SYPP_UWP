using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DTO.General.Button;
using SYPP.View.Components.Checklists;
using SYPP.View.Components.Contacts;
using SYPP.View.Components.Events;
using SYPP.View.Components.FollowUps;
using SYPP.View.Components.Notes;
using SYPP.View.Main;
using SYPP.ViewModel.ApplicationVM;
using SYPP.ViewModel.ComponentsVM.Checklist;
using SYPP.ViewModel.ComponentsVM.Contact;
using SYPP.ViewModel.ComponentsVM.Event;
using SYPP.ViewModel.ComponentsVM.FollowUp;
using SYPP.ViewModel.ComponentsVM.Note;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SYPP.View.Application.Detail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplicationDetailPage : Page
    {
        public ApplicationDetailViewModel MainVM;
        public ApplicationDetailPage()
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
                MainVM = new ApplicationDetailViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (ApplicationDetailViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ApplicationDetailViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            Add_Components_Button_PopUp.IsOpen = true;
            //Modify objects 
        }
        public async Task BlurredBackgroundOpen(bool open)
        {
            try
            {
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                await main.BlurredBackgroundOpen(open);
            }
            catch (Exception ex)
            {

            }
        }



        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________


        //___________________________________________________________________________________
        //
        // Filter Related Handlers - Below
        //___________________________________________________________________________________
        private void Content_Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    if (model.Text.Equals("All"))
                    {
                        UniformGrid.Columns = 5;
                        Events_Grid.Visibility = Visibility.Visible;
                        Notes_Grid.Visibility = Visibility.Visible;
                        Contacts_Grid.Visibility = Visibility.Visible;
                        ConvoHistory_Grid.Visibility = Visibility.Visible;
                        Checklists_Grid.Visibility = Visibility.Visible;
                    }
                    if (model.Text.Equals("Events"))
                    {
                        UniformGrid.Columns = 1;
                        Events_Grid.Visibility = Visibility.Visible;
                        Notes_Grid.Visibility = Visibility.Collapsed;
                        Contacts_Grid.Visibility = Visibility.Collapsed;
                        ConvoHistory_Grid.Visibility = Visibility.Collapsed;
                        Checklists_Grid.Visibility = Visibility.Collapsed;
                    }
                    if (model.Text.Equals("Notes"))
                    {
                        UniformGrid.Columns = 1;
                        Events_Grid.Visibility = Visibility.Collapsed;
                        Notes_Grid.Visibility = Visibility.Visible;
                        Contacts_Grid.Visibility = Visibility.Collapsed;
                        ConvoHistory_Grid.Visibility = Visibility.Collapsed;
                        Checklists_Grid.Visibility = Visibility.Collapsed;
                    }
                    if (model.Text.Equals("Contacts"))
                    {
                        UniformGrid.Columns = 1;
                        Events_Grid.Visibility = Visibility.Collapsed;
                        Notes_Grid.Visibility = Visibility.Collapsed;
                        Contacts_Grid.Visibility = Visibility.Visible;
                        ConvoHistory_Grid.Visibility = Visibility.Collapsed;
                        Checklists_Grid.Visibility = Visibility.Collapsed;
                    }
                    if (model.Text.Equals("Conversation Histories"))
                    {
                        UniformGrid.Columns = 1;
                        Events_Grid.Visibility = Visibility.Collapsed;
                        Notes_Grid.Visibility = Visibility.Collapsed;
                        Contacts_Grid.Visibility = Visibility.Collapsed;
                        ConvoHistory_Grid.Visibility = Visibility.Visible;
                        Checklists_Grid.Visibility = Visibility.Collapsed;
                    }
                    if (model.Text.Equals("Checklists"))
                    {
                        UniformGrid.Columns = 1;
                        Events_Grid.Visibility = Visibility.Collapsed;
                        Notes_Grid.Visibility = Visibility.Collapsed;
                        Contacts_Grid.Visibility = Visibility.Collapsed;
                        ConvoHistory_Grid.Visibility = Visibility.Collapsed;
                        Checklists_Grid.Visibility = Visibility.Visible;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Events Related Handlers - Below
        //___________________________________________________________________________________
        private async void Events_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Event)obj.DataContext;
                if(model != null)
                {
                    await BlurredBackgroundOpen(true);
                    var vm = new EventDetailedViewModel();
                    vm.applicationID = MainVM.Application_Selected.applicationID;
                    vm.Event = model;
                    vm.companyID = null;
                    vm.CreatingNewEvent = false;
                    await vm.LoadData();
                    Application_Components_Frame.Navigate(typeof(EventDetailedPage), vm);
                    Application_Components_Popup.IsOpen = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Notes Related Handlers - Below
        //___________________________________________________________________________________
        private async void Notes_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Note)obj.DataContext;
                if (model != null)
                {
                    await BlurredBackgroundOpen(true);
                    var vm = new NoteDetailedViewModel();
                    vm.applicationID = MainVM.Application_Selected.applicationID;
                    vm.Note = model;
                    vm.companyID = null;
                    vm.CreatingNewNote = false;
                    await vm.LoadData();
                    Application_Components_Frame.Navigate(typeof(NoteDetailedPage), vm);
                    Application_Components_Popup.IsOpen = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Contacts History Related Handlers - Below
        //___________________________________________________________________________________
        private async void Contacts_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Contact)obj.DataContext;
                if (model != null)
                {
                    await BlurredBackgroundOpen(true);
                    var vm = new ContactDetailedViewModel();
                    vm.companyID = null;
                    vm.applicationID = MainVM.Application_Selected.applicationID;
                    vm.Contact = model;
                    vm.CreatingNewContact = false;
                    await vm.LoadData();
                    Application_Components_Frame.Navigate(typeof(ContactDetailedPage), vm);
                    Application_Components_Popup.IsOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
        }   
        private async void Contact_Option_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    var contact_carrier = MainVM.Contacts.Where(x => x.contactID == model.correspondenceID).FirstOrDefault();
                    contact_carrier.Contacts_Selected = model;
                    foreach(var item in contact_carrier.Contacts)
                    {
                        if(item.Text == model.Text)
                        {
                            item.Background = "#C2DBFF";
                            item.Background_Hover = "#DBEAFF";
                            item.Background_Pressed = "#E3EFFF";
                            if (item.IconSource.Contains("Mail"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Mail_Selected_Icon.svg";
                            }
                            if (item.IconSource.Contains("Phone"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Phone_Selected_Icon.svg";
                            }
                            if (item.IconSource.Contains("Contact_Note"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Contact_Note_Selected_Icon.svg";
                            }
                        }
                        else
                        {
                            item.Background = "#5E6A7E";
                            item.Background_Hover = "#7D8CA8";
                            item.Background_Pressed = "#94A5C5";
                            if (item.IconSource.Contains("Mail"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Mail_UnSelected_Icon.svg";
                            }
                            if (item.IconSource.Contains("Phone"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Phone_UnSelected_Icon.svg";
                            }
                            if (item.IconSource.Contains("Contact_Note"))
                            {
                                item.IconSource = "/Assets/Components/Detailed/Contact_Note_UnSelected_Icon.svg";
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Convo History Related Handlers - Below
        //___________________________________________________________________________________

        private async void FollowUp_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (FollowUp)obj.DataContext;
                if (model != null)
                {
                    await BlurredBackgroundOpen(true);
                    var vm = new FollowUpDetailedViewModel();
                    vm.applicationID = MainVM.Application_Selected.applicationID;
                    vm.FollowUp = model;
                    vm.companyID = null;
                    vm.CreatingNewFollowUp = false;
                    await vm.LoadData();
                    Application_Components_Frame.Navigate(typeof(FollowUpDetailedPage), vm);
                    Application_Components_Popup.IsOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Checklist History Related Handlers - Below
        //___________________________________________________________________________________
        private async void Checklist_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Checklist)obj.DataContext;
                if (model != null)
                {
                    await BlurredBackgroundOpen(true);
                    var vm = new ChecklistDetailedViewModel();
                    vm.applicationID = MainVM.Application_Selected.applicationID;
                    vm.Checklist = model;
                    vm.companyID = null;
                    vm.CreatingNewChecklist = false;
                    await vm.LoadData();
                    Application_Components_Frame.Navigate(typeof(ChecklistDetailedPage), vm);
                    Application_Components_Popup.IsOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Checklist Related Handlers - Below
        //___________________________________________________________________________________

        private void Checklist_Options_Frame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Frame;
                var model = (SYPP.Model.DB.Components.File.File)obj.DataContext;
                if(model != null)
                {
                    model.IsChecked = !model.IsChecked;
                    model.UpdateCheckUI();
                }
            }
            catch(Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Add Components Related Handlers - Below
        //___________________________________________________________________________________
        private void Add_Components_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddComponents_GridView_Popup.IsOpen = true;
            }
            catch(Exception ex)
            {

            }
        }

        private async void Add_Components_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    if (model.Text.Contains("Events"))
                    {
                        await BlurredBackgroundOpen(true);
                        var vm = new EventDetailedViewModel();
                        vm.applicationID = MainVM.Application_Selected.applicationID;
                        vm.CreatingNewEvent = true;
                        await vm.LoadData();
                        Application_Components_Frame.Navigate(typeof(EventDetailedPage), vm);
                        Application_Components_Popup.IsOpen = true;
                    }
                    if (model.Text.Contains("Notes"))
                    {
                        await BlurredBackgroundOpen(true);
                        var vm = new NoteDetailedViewModel();
                        vm.applicationID = MainVM.Application_Selected.applicationID;
                        vm.CreatingNewNote = true;
                        vm.companyID = null;
                        await vm.LoadData();
                        Application_Components_Frame.Navigate(typeof(NoteDetailedPage), vm);
                        Application_Components_Popup.IsOpen = true;
                    }
                    if (model.Text.Contains("Contacts"))
                    {
                        await BlurredBackgroundOpen(true);
                        var vm = new ContactDetailedViewModel();
                        vm.companyID = null;
                        vm.applicationID = MainVM.Application_Selected.applicationID;
                        vm.CreatingNewContact = true;
                        await vm.LoadData();
                        Application_Components_Frame.Navigate(typeof(ContactDetailedPage), vm);
                        Application_Components_Popup.IsOpen = true;
                    }
                    if (model.Text.Contains("Conversation"))
                    {
                        await BlurredBackgroundOpen(true);
                        var vm = new FollowUpDetailedViewModel();
                        vm.applicationID = MainVM.Application_Selected.applicationID;
                        vm.companyID = null;
                        vm.CreatingNewFollowUp = true;
                        await vm.LoadData();
                        Application_Components_Frame.Navigate(typeof(FollowUpDetailedPage), vm);
                        Application_Components_Popup.IsOpen = true;
                    }
                    if (model.Text.Contains("Checklists"))
                    {
                        await BlurredBackgroundOpen(true);
                        var vm = new ChecklistDetailedViewModel();
                        vm.applicationID = MainVM.Application_Selected.applicationID;
                        vm.companyID = null;
                        vm.CreatingNewChecklist = true;
                        await vm.LoadData();
                        Application_Components_Frame.Navigate(typeof(ChecklistDetailedPage), vm);
                        Application_Components_Popup.IsOpen = true;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void Application_Components_Popup_Closed(object sender, object e)
        {
            await BlurredBackgroundOpen(false);
        }

    }
}
