using SYPP.Converter.ColorConverter;
using SYPP.Model.DTO.General.Button;
using SYPP.Utilities.Storage;
using SYPP.View.Application;
using SYPP.View.Calendar;
using SYPP.View.Company;
using SYPP.View.Template;
using SYPP.ViewModel.ApplicationVM;
using SYPP.ViewModel.CalendarVM;
using SYPP.ViewModel.CompanyVM;
using SYPP.ViewModel.MainBoardVM;
using SYPP.ViewModel.TemplateVM;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SYPP.View.Main
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainBoard : Page
    {
        public MainBoardViewModel MainVM;
        public MainBoard()
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
                MainVM = new MainBoardViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (MainBoardViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (MainBoardViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            await NavigateToApplicationsPage();
            await SetTitleBarColors();
            //Modify objects 
        }
        public async Task BlurredBackgroundOpen(bool open)
        {
            try
            {
                if (open)
                {
                    BlurBehavior.Value = 5;
                    BlurredBackground.IsOpen = true;
                }
                else
                {
                    BlurBehavior.Value = 0;
                    BlurredBackground.IsOpen = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public async Task SetTitleBarColors()
        {
            try
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ForegroundColor = Windows.UI.Colors.White;
                titleBar.BackgroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#1A1C20");
                titleBar.ButtonForegroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#FAFFFFFF");
                titleBar.ButtonBackgroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#1A1C20");
                titleBar.ButtonHoverForegroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#FAFFFFFF");
                titleBar.ButtonHoverBackgroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#FAFFFFFF");
                titleBar.ButtonPressedForegroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#FAFFFFFF");
                titleBar.ButtonPressedBackgroundColor = StringToSolidColorBrushConverter.ConvertToWindowsUI("#FAFFFFFF");
            }
            catch(Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Navigation Handlers - Below
        //___________________________________________________________________________________
        private async void Navigation_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    foreach(var item in MainVM.Navigations)
                    {
                        if (model.Text == item.Text)
                        {
                            if(item.Text == "Calendar")
                            {
                                await NavigateToCalendar();
                                item.IconSource = "/Assets/Navigations/Calendar_Navigation_Selected_Icon.svg";
                                item.Background = "#C2DBFF";
                                item.Background_Hover = "#C2DBFF";
                                item.Background_Pressed = "#C2DBFF";
                                item.Foreground = "#1A1C20";
                            }
                            if (item.Text == "Applications")
                            {
                                await NavigateToApplicationsPage();
                                item.IconSource = "/Assets/Navigations/Applications_Navigation_Selected_Icon.svg";
                                item.Background = "#C2DBFF";
                                item.Background_Hover = "#C2DBFF";
                                item.Background_Pressed = "#C2DBFF";
                                item.Foreground = "#1A1C20";
                            }
                            if (item.Text == "Companies")
                            {
                                await NavigateToCompaniesPage();
                                item.IconSource = "/Assets/Navigations/Applications_Navigation_Selected_Icon.svg";
                                item.Background = "#C2DBFF";
                                item.Background_Hover = "#C2DBFF";
                                item.Background_Pressed = "#C2DBFF";
                                item.Foreground = "#1A1C20";
                            }
                            if (item.Text == "Templates")
                            {
                                await NavigateToTemplatesPage();
                                item.IconSource = "/Assets/Navigations/Templates_Navigation_Selected_Icon.svg";
                                item.Background = "#C2DBFF";
                                item.Background_Hover = "#C2DBFF";
                                item.Background_Pressed = "#C2DBFF";
                                item.Foreground = "#1A1C20";
                            }
                        }
                        else
                        {
                            if (item.Text == "Calendar")
                            {
                                item.IconSource = "/Assets/Navigations/Calendar_Navigation_UnSelected_Icon.svg";
                                item.Background = "#363C46";
                                item.Background_Hover = "#7D8CA8";
                                item.Background_Pressed = "#94A5C5";
                                item.Foreground = "#C2DBFF";
                            }
                            if (item.Text == "Applications")
                            {
                                item.IconSource = "/Assets/Navigations/Applications_Navigation_UnSelected_Icon.svg";
                                item.Background = "#363C46";
                                item.Background_Hover = "#7D8CA8";
                                item.Background_Pressed = "#94A5C5";
                                item.Foreground = "#C2DBFF";
                            }
                            if (item.Text == "Companies")
                            {
                                item.IconSource = "/Assets/Navigations/Applications_Navigation_UnSelected_Icon.svg";
                                item.Background = "#363C46";
                                item.Background_Hover = "#7D8CA8";
                                item.Background_Pressed = "#94A5C5";
                                item.Foreground = "#C2DBFF";
                            }
                            if (item.Text == "Templates")
                            {
                                item.IconSource = "/Assets/Navigations/Templates_Navigation_UnSelected_Icon.svg";
                                item.Background = "#363C46";
                                item.Background_Hover = "#7D8CA8";
                                item.Background_Pressed = "#94A5C5";
                                item.Foreground = "#C2DBFF";
                            }
                            
                        }
                        
                    }
                    
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task NavigateToCalendar()
        {
            try
            {
                var CalendarVM = new CalendarViewModel();
                await CalendarVM.LoadData();
                Main_Contents_Frame.Navigate(typeof(CalendarPage), CalendarVM);

                LocalStorage.Coordinate = 10;
            }
            catch(Exception ex)
            {

            }
        }
        public async Task NavigateToApplicationsPage()
        {
            try
            {
                var ApplicationVM = new ApplicationViewModel();
                await ApplicationVM.LoadData();
                Main_Contents_Frame.Navigate(typeof(ApplicationsPage), ApplicationVM);

                LocalStorage.Coordinate = 20;
            }
            catch(Exception ex)
            {

            }
        }
        public async Task NavigateToCompaniesPage()
        {
            try
            {
                var CompanyVM = new CompanyViewModel();
                await CompanyVM.LoadData();
                Main_Contents_Frame.Navigate(typeof(CompaniesPage), CompanyVM);

                LocalStorage.Coordinate = 30;
            }
            catch (Exception ex)
            {

            }
        }
        public async Task NavigateToTemplatesPage()
        {
            try
            {
                var TemplateVM = new TemplateViewModel();
                await TemplateVM.LoadData();
                Main_Contents_Frame.Navigate(typeof(TemplatePage), TemplateVM);

                LocalStorage.Coordinate = 40;
            }
            catch(Exception ex)
            {

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
