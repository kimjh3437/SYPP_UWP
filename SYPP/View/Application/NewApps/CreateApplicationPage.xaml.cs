using SYPP.Converter.ColorConverter;
using SYPP.Model.DTO.General.Button;
using SYPP.Model.DTO.General.Components;
using SYPP.View.Main;
using SYPP.ViewModel.ApplicationVM.NewAppsVM;
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

namespace SYPP.View.Application.NewApps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateApplicationPage : Page
    {
        public CreateApplicationViewModel MainVM;
        public CreateApplicationPage()
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
                MainVM = new CreateApplicationViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (CreateApplicationViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (CreateApplicationViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            //Modify objects 
        }

        private void Navigation_Circle_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    if(model.Text == "1")
                    {
                        CreateApplicaiton_Content_One_Grid.Visibility = Visibility.Visible;
                        CreateApplicaiton_Content_Two_Grid.Visibility = Visibility.Collapsed;
                        CreateApplicaiton_Content_Three_Grid.Visibility = Visibility.Collapsed;
                        foreach (var nav in MainVM.Navigations)
                        {
                            if (nav.Text == "1")
                            {
                                nav.Background = "#C2DBFF";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#DBEAFF";
                                nav.Background_Pressed = "#E3EFFF";
                            }
                            else
                            {
                                nav.Background = "#363C46";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#7D8CA8";
                                nav.Background_Pressed = "#94A5C5";
                            }
                        }
                    }
                    if (model.Text == "2")
                    {
                        CreateApplicaiton_Content_One_Grid.Visibility = Visibility.Collapsed;
                        CreateApplicaiton_Content_Two_Grid.Visibility = Visibility.Visible;
                        CreateApplicaiton_Content_Three_Grid.Visibility = Visibility.Collapsed;
                        foreach (var nav in MainVM.Navigations)
                        {
                            if (nav.Text == "2")
                            {
                                nav.Background = "#C2DBFF";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#DBEAFF";
                                nav.Background_Pressed = "#E3EFFF";
                            }
                            else
                            {
                                nav.Background = "#363C46";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#7D8CA8";
                                nav.Background_Pressed = "#94A5C5";
                            }
                        }
                    }
                    if (model.Text == "3")
                    {
                        CreateApplicaiton_Content_One_Grid.Visibility = Visibility.Collapsed;
                        CreateApplicaiton_Content_Two_Grid.Visibility = Visibility.Collapsed;
                        CreateApplicaiton_Content_Three_Grid.Visibility = Visibility.Visible;
                        foreach (var nav in MainVM.Navigations)
                        {
                            if (nav.Text == "3")
                            {
                                nav.Background = "#C2DBFF";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#DBEAFF";
                                nav.Background_Pressed = "#E3EFFF";
                            }
                            else
                            {
                                nav.Background = "#363C46";
                                nav.Foreground = "#242931";
                                nav.Background_Hover = "#7D8CA8";
                                nav.Background_Pressed = "#94A5C5";
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
        // Page One Handlers - Below
        //___________________________________________________________________________________

        private void Company_Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!String.IsNullOrEmpty(obj.Text))
                {
                    MainVM.CompanyName = obj.Text;
                    if(!String.IsNullOrEmpty(MainVM.CompanyName) && !String.IsNullOrEmpty(MainVM.PositionTitle))
                    {
                        Page_One_Next_Button.IsEnabled = true;
                    }
                    else
                    {
                        Page_One_Next_Button.IsEnabled = false;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Position_Title_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!String.IsNullOrEmpty(obj.Text))
                {
                    MainVM.PositionTitle = obj.Text;
                    if (!String.IsNullOrEmpty(MainVM.CompanyName) && !String.IsNullOrEmpty(MainVM.PositionTitle))
                    {
                        Page_One_Next_Button.IsEnabled = true;
                    }
                    else
                    {
                        Page_One_Next_Button.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Page_One_Next_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateApplicaiton_Content_One_Grid.Visibility = Visibility.Collapsed;
                CreateApplicaiton_Content_Two_Grid.Visibility = Visibility.Visible;
                CreateApplicaiton_Content_Three_Grid.Visibility = Visibility.Collapsed;
                foreach(var nav in MainVM.Navigations)
                {
                    if(nav.Text == "2")
                    {
                        nav.Background = "#C2DBFF";
                        nav.Foreground = "#242931";
                        nav.Background_Hover = "#DBEAFF";
                        nav.Background_Pressed = "#E3EFFF";
                    }
                    else
                    {
                        nav.Background = "#363C46";
                        nav.Foreground = "#242931";
                        nav.Background_Hover = "#7D8CA8";
                        nav.Background_Pressed = "#94A5C5";
                    }
                }
            }
            catch(Exception ex) 
            { 
            }
        }


        //___________________________________________________________________________________
        //
        // Page Two Handlers - Below
        //___________________________________________________________________________________
        private void Create_NewRole_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Do Nothing
            }
            catch(Exception ex)
            {

            }
        }

        private void CreatedRole_Item_TriDots_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    model.PopUp_IsOpen = true;
                }
            }
            catch(Exception ex) 
            {
            }
        }

        private void Create_NewRole_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!String.IsNullOrEmpty(obj.Text))
                {
                    if(e.Key == Windows.System.VirtualKey.Enter)
                    {
                        MainVM.CreatedRoles.Add(new Model.DTO.General.Button.Text_Button_DTO 
                        {
                            Text = obj.Text,
                            PopUp_IsOpen = false
                        });
                        obj.Text = "";
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Popup_Closed(object sender, object e)
        {
            var obj = sender as Popup;
            var model = (Text_Button_DTO)obj.DataContext;
            if(model != null) 
            {
                model.PopUp_IsOpen = false;
            }
        }

        private void RoleCreated_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = sender as Button;
            var model = (Text_Button_DTO)obj.DataContext;
            if (model != null)
            {
                MainVM.CreatedRoles.Remove(MainVM.CreatedRoles.Where(x => x.Text == model.Text).FirstOrDefault());
            }
        }

        private void CreatedLocations_Item_TriDots_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if (model != null)
                {
                    model.PopUp_IsOpen = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Locations_PopUp_Closed(object sender, object e)
        {
            var obj = sender as Popup;
            var model = (Text_Button_DTO)obj.DataContext;
            if (model != null)
            {
                model.PopUp_IsOpen = false;
            }
        }

        private void LocationsCreated_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = sender as Button;
            var model = (Text_Button_DTO)obj.DataContext;
            if (model != null)
            {
                MainVM.CreatedLocations.Remove(MainVM.CreatedLocations.Where(x => x.Text == model.Text).FirstOrDefault());
            }
        }

        private void Create_Location_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!String.IsNullOrEmpty(obj.Text))
                {
                    if (e.Key == Windows.System.VirtualKey.Enter)
                    {
                        MainVM.CreatedLocations.Add(new Model.DTO.General.Button.Text_Button_DTO
                        {
                            Text = obj.Text,
                            PopUp_IsOpen = false
                        });
                        obj.Text = "";
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Create_Location_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Page_Two_Next_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateApplicaiton_Content_One_Grid.Visibility = Visibility.Collapsed;
            CreateApplicaiton_Content_Two_Grid.Visibility = Visibility.Collapsed;
            CreateApplicaiton_Content_Three_Grid.Visibility = Visibility.Visible;
            foreach (var nav in MainVM.Navigations)
            {
                if (nav.Text == "3")
                {
                    nav.Background = "#C2DBFF";
                    nav.Foreground = "#242931";
                    nav.Background_Hover = "#DBEAFF";
                    nav.Background_Pressed = "#E3EFFF";
                }
                else
                {
                    nav.Background = "#363C46";
                    nav.Foreground = "#242931";
                    nav.Background_Hover = "#7D8CA8";
                    nav.Background_Pressed = "#94A5C5";
                }
            }
        }
        private void New_Category_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainVM.CustomCategories.Add(new Model.DTO.General.Components.Category_DTO
                {
                    Type = "",
                    Options = new System.Collections.ObjectModel.ObservableCollection<Text_Button_DTO>()
                });
            }
            catch(Exception ex)
            {

            }
        }
        private void Custom_Role_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                var model = (Category_DTO)obj.DataContext;
                if(model != null)
                {
                    model.Type = obj.Text;
                    model.Placeholder_Text = $"Type to create new {obj.Text}";
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void Create_CustomCategory_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
            }
            catch(Exception ex)
            {

            }
        }

        private void Create_CustomCategory_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                var model = (Category_DTO)obj.DataContext;
                if (model != null)
                {
                    if (e.Key == Windows.System.VirtualKey.Enter)
                    {
                        if (!String.IsNullOrEmpty(obj.Text))
                        {
                            var category = MainVM.CustomCategories.Where(x => x.Type == model.Type).FirstOrDefault();
                            if (category != null)
                            {
                                category.Options.Add(new Text_Button_DTO
                                {
                                    Text = obj.Text,
                                    PopUp_IsOpen = false,
                                    Type = model.Type
                                });
                            }
                            obj.Text = "";
                        }                
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Custom_Category_PopUp_Closed(object sender, object e)
        {
            try
            {
                var obj = sender as Popup;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    model.PopUp_IsOpen = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void CustomCategory_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if (model != null)
                {
                    var category = MainVM.CustomCategories.Where(x => x.Type == model.Type).FirstOrDefault();
                    if(category != null)
                    {
                        category.Options.Remove(category.Options.Where(x => x.Text == model.Text).FirstOrDefault());
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void CreatedCustomeCategory_Item_TriDots_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    model.PopUp_IsOpen = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Page Three Handlers - Below
        //___________________________________________________________________________________

        private void HaveYouApplied_Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HaveYouApplied_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
                HaveYouApplied_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
                HaveYouApplied_No_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
                HaveYouApplied_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
                MainVM.HaveYouApplied = true;
            }
            catch(Exception ex) {}
        }

        private void HaveYouApplied_No_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HaveYouApplied_No_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
                HaveYouApplied_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
                HaveYouApplied_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
                HaveYouApplied_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
                MainVM.HaveYouApplied = false;
            }
            catch(Exception ex)
            {

            }
        }

        private void DisplayThisDate_Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayThisDate_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            DisplayThisDate_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
            DisplayThisDate_No_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
            DisplayThisDate_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            MainVM.DisplayThisDate = true;
            Page_Three_Save_Button.IsEnabled = true;
        }

        private void DisplayThisDate_No_Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayThisDate_No_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            DisplayThisDate_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
            DisplayThisDate_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
            DisplayThisDate_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            MainVM.DisplayThisDate = false;
            Page_Three_Save_Button.IsEnabled = true;
        }

        private async void Month_Prev_Button_Click(object sender, RoutedEventArgs e)
        {
            MainVM.SelectedTime = MainVM.SelectedTime.AddMonths(-1);
            await MainVM.PopulateCalendar();
        }

        private async void Month_Next_Button_Click(object sender, RoutedEventArgs e)
        {
            MainVM.SelectedTime = MainVM.SelectedTime.AddMonths(1);
            await MainVM.PopulateCalendar();
        }

        private async void Year_Prev_Button_Click(object sender, RoutedEventArgs e)
        {
            MainVM.SelectedTime = MainVM.SelectedTime.AddYears(-1);
            await MainVM.PopulateCalendar();
        }

        private async void Year_Next_Button_Click(object sender, RoutedEventArgs e)
        {
            MainVM.SelectedTime = MainVM.SelectedTime.AddYears(1);
            await MainVM.PopulateCalendar();
        }

        private async void Page_Three_Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.CreateApplication();
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                var application = main.Main_Contents_Frame.Content as ApplicationsPage;
                application.New_Application_Popup.IsOpen = false;
            }
            catch(Exception ex)
            {

            }
        }

        private void Day_TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBlock;
                var model = (Text_Button_DTO)obj.DataContext;
                if (model != null)
                {
                    var prev = MainVM.EachMonth.Where(x => x.DateTime == MainVM.SelectedTime).FirstOrDefault();
                    if(prev != null)
                    {
                        prev.Foreground = "#7D8CA8";
                    }
                    MainVM.EachMonth.Where(x => x.DateTime == model.DateTime).FirstOrDefault().Foreground = "#C2DBFF";
                    MainVM.SelectedTime = model.DateTime;
                }
                Page_Three_Save_Button.IsEnabled = true;
            } 
            catch (Exception ex) { }
        }
        public async Task CheckAllInfosAreFilled() 
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }
   
    }
}
