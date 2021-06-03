using SYPP.Model.DB.Components.Categories;
using SYPP.Model.DB.Components.Tasks;
using SYPP.Model.DTO.Calendar;
using SYPP.Utilities.Storage;
using SYPP.View.Application.Detail;
using SYPP.View.Application.NewApps;
using SYPP.View.Application.NewTask;
using SYPP.View.Main;
using SYPP.ViewModel.ApplicationVM;
using SYPP.ViewModel.ApplicationVM.NewAppsVM;
using SYPP.ViewModel.ApplicationVM.NewTaskVM;
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

namespace SYPP.View.Application
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ApplicationsPage : Page
    {
        public ApplicationViewModel MainVM;
        public ApplicationsPage()
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
                MainVM = new ApplicationViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (ApplicationViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (ApplicationViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            await InitSettings();
            //await MainVM.PopulateApplications();
            //Modify objects 
        }
        public async Task InitSettings()
        {
            try
            {
                NewApplication_Button_PopUp.IsOpen = true;
            }
            catch(Exception ex)
            {

            }
        }
        public async Task BlurredBackgroundOpen(bool open)
        {
            try
            {
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                await main.BlurredBackgroundOpen(open);
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        //Display Options 
        private void Hide_Weekly_Schedule_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Display_Weekly_Schedule_Button.Visibility = Visibility.Visible;
                var obj = sender as Button;
                obj.Visibility = Visibility.Collapsed;
                Weekly_Schedule_Calendar_GridView.Visibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {

            }
        }
        private void Display_Weekly_Schedule_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hide_Weekly_Schedule_Button.Visibility = Visibility.Visible;
                var obj = sender as Button;
                obj.Visibility = Visibility.Collapsed;
                Weekly_Schedule_Calendar_GridView.Visibility = Visibility.Visible;
            }
            catch(Exception ex)
            {

            }
         
        }

        private async void Each_Calendar_Event_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
             
            }
            catch(Exception ex)
            {

            }
        }

        private void Icon_Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var vm = (Calendar_Event_DTO)obj.DataContext;
                vm.Task.IsFavorite = !vm.Task.IsFavorite;
                vm.UpdateUI();
                var time = vm.Task.Time;
                var item = MainVM.WeeklyCalendar.Where(x => x.Date.Day == time.Day && x.Date.Month == time.Month).FirstOrDefault();
                item.UpdateBorderColor();
            }
            catch(Exception ex)
            {

            }
        }

        private void Active_Applications_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Archived_Applications_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Category_Type_Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Grid;
                var model = (Popup)obj.Children[1];
                if (model != null) 
                {
                    model.IsOpen = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Category_Type_Grid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var obj = sender as Grid;
            var model = (Popup)obj.Children[1];
            if (model != null)
            {
                model.IsOpen = false;
            }
        }

        private void IsFavorite_Star_Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var model = (SYPP.Model.DB.Application)obj.DataContext;
                if(model != null)
                {
                    model.Detail.IsFavorite = !model.Detail.IsFavorite;
                    model.UpdateFavoriteStatus();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void HasApplied_Status_Frame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Frame;
                var model = (SYPP.Model.DB.Application)obj.DataContext;
                if(model != null)
                {
                    model.Detail.Status.Where(x => x.Title == "Submission").FirstOrDefault().Status = !model.Detail.Status.Where(x => x.Title == "Submission").FirstOrDefault().Status;
                    model.Detail.HasApplied = !model.Detail.HasApplied;
                    model.Detail.UpdateHasAppliedStatus();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Result_Status_Frame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Frame;
                var model = (SYPP.Model.DB.Application)obj.DataContext;
                if (model != null)
                {
                    model.Detail.Status.Where(x => x.Title == "Results").FirstOrDefault().Status = !model.Detail.Status.Where(x => x.Title == "Results").FirstOrDefault().Status;
                    model.Detail.HasResult = !model.Detail.HasResult;
                    model.Detail.UpdateResultStatus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Application_MidTask_Status_Frame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Frame;
                var model = (MidTask)obj.DataContext;
                if (model != null)
                {
                    model.Status = !model.Status;
                    model.UpdateStatus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //Adds MisTask 
        private async void Application_MidTask_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (SYPP.Model.DB.Application)obj.DataContext;
                if(model != null)
                {
                    var newTask = new CreateNewTaskViewModel();
                    newTask.applicationID = model.applicationID;
                    await newTask.LoadData();
                    await BlurredBackgroundOpen(true);
                    New_Task_Frame.Navigate(typeof(NewTaskPage), newTask);
                    New_Task_Popup.IsOpen = true;
                }
                
            }
            catch(Exception ex)
            {

            }
        }

        private void Application_Result_Add_Image_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }



        private async void Application_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (SYPP.Model.DB. Application)obj.DataContext;
                if(model != null)
                {
                    if(MainVM.Application_Selected_Prev != null)
                    {
                        var app_prev = MainVM.Applications.Where(x => x.applicationID == MainVM.Application_Selected_Prev.applicationID).FirstOrDefault();
                        app_prev.IsSelected = false;
                        app_prev.UpdateUI();
                    }
                    MainVM.Application_Selected_Prev = model;
                    MainVM.Application_Selected = model;
                    var app = MainVM.Applications.Where(x => x.applicationID == model.applicationID).FirstOrDefault();
                    app.IsSelected = true;
                    app.UpdateUI();
                    var detailVM = new ApplicationDetailViewModel();
                    detailVM.Application_Selected = model;
                    await detailVM.LoadData();
                    Application_Detail_Frame.Navigate(typeof(ApplicationDetailPage), detailVM);

                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Category Filter Related Handlers - Below
        //___________________________________________________________________________________
        private void Category_Type_Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = sender as Button;
            var model = (Category)obj.DataContext;
            if(model != null)
            {
                model.Category_PopUp_IsOpen = true;
            }
        }

        private void Category_Filter_Type_List_PopUp_Closed(object sender, object e)
        {
            try
            {
                var obj = sender as Popup;
                var model = (Category)obj.DataContext;
                if(model != null)
                {
                    model.Category_PopUp_IsOpen = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void Category_Specific_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Category_Suggestion)obj.DataContext;
                if(model != null)
                {
                    MainVM.Filter_Selected = model.Content;
                    await MainVM.PopulateApplications();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void New_Application_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await BlurredBackgroundOpen(true);
                var newappVM = new CreateApplicationViewModel();
                await newappVM.LoadData();
                New_Application_Frame.Navigate(typeof(CreateApplicationPage), newappVM);
                New_Application_Popup.IsOpen = true;
            }
            catch(Exception ex)
            {

            }
        }

        private async void New_Application_Popup_Closed(object sender, object e)
        {
            await BlurredBackgroundOpen(false);
        }

        private void New_Task_Popup_Closed(object sender, object e)
        {

        }
    }
}
