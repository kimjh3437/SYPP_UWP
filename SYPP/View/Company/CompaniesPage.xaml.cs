using SYPP.Model.DTO.Calendar;
using SYPP.View.Company.Detail;
using SYPP.View.Main;
using SYPP.ViewModel.CompanyVM;
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

namespace SYPP.View.Company
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CompaniesPage : Page
    {
        public CompanyViewModel MainVM;
        public CompaniesPage()
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
                MainVM = new CompanyViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (CompanyViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (CompanyViewModel)e.Parameter;
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
               NewCompany_Button_PopUp.IsOpen = true;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Weekly Calendar Related Handlers - Below
        //___________________________________________________________________________________
        private void Calendar_Item_Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var model = (Calendar_Event_DTO)obj.DataContext;
                if(model != null)
                {
                    model.Detail.IsFavorite = !model.Detail.IsFavorite;
                    model.UpdateUI();
                }
                    
            }
            catch(Exception ex)
            {

            }
        }
        private void Hide_Weekly_Schedule_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Display_Weekly_Schedule_Button.Visibility = Visibility.Visible;
                var obj = sender as Button;
                obj.Visibility = Visibility.Collapsed;
                Weekly_Schedule_Calendar_GridView.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {

            }

        }
        private async void Each_Calendar_Event_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void Selected_Company_IsFavorite_Star_Image_Tapped(object sender, TappedRoutedEventArgs e)
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
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Companies Related Handlers - Below
        //___________________________________________________________________________________
        private void IsFavorite_Star_Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var model = (SYPP.Model.DB.Companies.Company)obj.DataContext;
                if (model != null)
                {
                    model.Detail.IsFavorite = !model.Detail.IsFavorite;
                    model.UpdateFavoriteStatus();
                }
            }
            catch(Exception ex) { }
        }

        private async void New_Company_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await BlurredBackgroundOpen(true);
                NewCompany_Create_PopUp.IsOpen = true;
            }
            catch (Exception ex)
            {

            }

        }

        private async void Company_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (SYPP.Model.DB.Companies.Company)obj.DataContext;
                if(model != null)
                {
                    if (MainVM.Company_Selected_Prev != null)
                    {
                        var company_prev = MainVM.Companies.Where(x => x.companyID == MainVM.Company_Selected_Prev.companyID).FirstOrDefault();
                        company_prev.IsSelected = false;
                        company_prev.UpdateUI();
                    }
                    MainVM.Company_Selected_Prev = model;
                    MainVM.Company_Selected = model;
                    var company = MainVM.Companies.Where(x => x.companyID == model.companyID).FirstOrDefault();
                    company.IsSelected = true;
                    company.UpdateUI();
                    var detailVM = new CompanyDetailViewModel();
                    detailVM.Company_Selected = model;
                    await detailVM.LoadData();
                    Company_Detail_Frame.Navigate(typeof(CompanyDetailedPage), detailVM);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void NewCompany_Create_PopUp_Closed(object sender, object e)
        {
            try
            {
                await BlurredBackgroundOpen(false);
            }
            catch(Exception ex)
            {

            }

        }

        private void Create_Company_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!string.IsNullOrEmpty(obj.Text)) 
                {
                    MainVM.CompanyName = obj.Text;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            await MainVM.CreateCopmany();
            Create_Company_TextBox.Text = "";
            await BlurredBackgroundOpen(false);
            NewCompany_Create_PopUp.IsOpen = false;
        }
    }
}
