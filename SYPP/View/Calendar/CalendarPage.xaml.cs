using SYPP.Model.DTO.Calendar;
using SYPP.View.Main;
using SYPP.ViewModel.CalendarVM;
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

namespace SYPP.View.Calendar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarPage : Page
    {
        public CalendarViewModel MainVM;
        public CalendarPage()
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
                MainVM = new CalendarViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (CalendarViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (CalendarViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            //Modify objects 
        }




        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        private async void LeftArrow_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.GoOverPrevMonth();
            }
            catch(Exception ex)
            {

            }
        }

        private async void RightArrow_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.GoOverNextMonth();
            }
            catch(Exception ex)
            {

            }     
        }

        private async void Today_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.RestoreCalendarToday();
            }
            catch(Exception ex)
            {

            }         
        }

        private async void Icon_Favorite_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var vm = (Calendar_Event_DTO)obj.DataContext;
                vm.Task.IsFavorite = !vm.Task.IsFavorite;
                vm.UpdateUI();
                var time = vm.Task.Time;
                var item = MainVM.EachMonth.Where(x => x.Date.Day == time.Day && x.Date.Month == time.Month).FirstOrDefault();
                item.UpdateBorderColor();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void Each_Calendar_Event_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var obj = sender as Grid;
            var model = (Calendar_Event_DTO)obj.DataContext;
            if (model != null)
            {
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                var dbc = (MainBoardViewModel)main.DataContext;
                //main.SetContentsOnAddPopUp("Calendar", model, model.applicationID, "Calendar");
            }
        }

        private void CalendarMonth_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((ItemsWrapGrid)CalendarMonth.ItemsPanelRoot).ItemWidth = e.NewSize.Width / 7;
        }

       

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
    }
}
