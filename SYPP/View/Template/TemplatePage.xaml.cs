using SYPP.Model.DTO.Calendar;
using SYPP.View.Main;
using SYPP.ViewModel.TemplateVM;
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

namespace SYPP.View.Template
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TemplatePage : Page
    {
        public TemplateViewModel MainVM;
        public TemplatePage()
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
                MainVM = new TemplateViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (TemplateViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (TemplateViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            NewTemplate_Button_PopUp.IsOpen = true;
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
        // Calendar Related Handlers - Below
        //___________________________________________________________________________________
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
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Template Options Related Handlers - Below
        //___________________________________________________________________________________
        private void Search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void New_Template_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach(var item in MainVM.Templates)
                {
                    item.IsSelected = false;
                    item.UpdateUI();
                }
                var vm = new TemplateDetailViewModel();
                vm.CreatingTemplate = true;
                vm.Template_Selected = new Model.DB.Template.Template 
                {
                    Detail = new Model.DB.Template.Template_Detail
                    {

                    },
                    Content = new Model.DB.Template.Template_Content
                    {

                    }
                };
                await vm.LoadData();
                Template_Contents_Frame.Navigate(typeof(TemplateDetailedPage), vm);
            }
            catch (Exception ex)
            {

            }
        }

        private void Filter_Option_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IsFavorite_Star_Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Image;
                var model = (SYPP.Model.DB.Template.Template)obj.DataContext;
                if (model != null)
                {
                    model.Detail.IsFavorite = !model.Detail.IsFavorite;
                    model.UpdateFavoriteStatus();
                }
            }
            catch (Exception ex) { }
        }

        private async void Template_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (SYPP.Model.DB.Template.Template)obj.DataContext;
                if (model != null)
                {
                    if (MainVM.Template_Selected_Prev != null)
                    {
                        var app_prev = MainVM.Templates.Where(x => x.templateID == MainVM.Template_Selected_Prev.templateID).FirstOrDefault();
                        app_prev.IsSelected = false;
                        app_prev.UpdateUI();
                    }
                    MainVM.Template_Selected_Prev = model;
                    MainVM.Template_Selected = model;
                    model.IsSelected = true;
                    model.UpdateUI();

                    var vm = new TemplateDetailViewModel();
                    vm.CreatingTemplate = false;
                    vm.Template_Selected = model;
                    await vm.LoadData();
                    Template_Contents_Frame.Navigate(typeof(TemplateDetailedPage), vm);
                }
            }
            catch (Exception ex) { }
        }
    }
}
