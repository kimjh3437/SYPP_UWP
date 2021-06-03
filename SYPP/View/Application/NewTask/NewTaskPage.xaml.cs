using SYPP.Converter.ColorConverter;
using SYPP.Model.DTO.General.Button;
using SYPP.View.Main;
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

namespace SYPP.View.Application.NewTask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewTaskPage : Page
    {
        public CreateNewTaskViewModel MainVM;
        public NewTaskPage()
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
                MainVM = new CreateNewTaskViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (CreateNewTaskViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (CreateNewTaskViewModel)e.Parameter;
            this.DataContext = param;
            await InitializeDataContext();
            //await MainVM.PopulateApplications();
            //Modify objects 
        }

        //___________________________________________________________________________________
        //
        // Page 1 Event Handlers - Below
        //___________________________________________________________________________________
        private void Navigation_Circle_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;                
                if(model != null)
                {
                    if (model.Text.Equals("1"))
                    {
                        Page_One_Grid.Visibility = Visibility.Visible;
                        Page_Two_Grid.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        Page_One_Grid.Visibility = Visibility.Collapsed;
                        Page_Two_Grid.Visibility = Visibility.Visible;
                    }
                    foreach (var item in MainVM.Navigations)
                    {
                        if(item.Text == model.Text)
                        {
                            item.Background = "#C2DBFF";                    
                        }
                        else
                        {
                            item.Background = "#363C46";
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void StepOption_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (Text_Button_DTO)obj.DataContext;
                if(model != null)
                {
                    MainVM.Step_Selected = model;
                    foreach(var item in MainVM.StepOptions)
                    {
                        if(item.Text == model.Text)
                        {
                            item.Background = "#C2DBFF";
                            item.Foreground = "#363C46";
                        }
                        else
                        {
                            item.Foreground = "#C2DBFF";
                            item.Background = "#363C46";
                        }
                    }
                }
                Page_One_Next_Button.IsEnabled = true;
            }
            catch(Exception ex)
            {

            }
        }

        private void Custome_StepName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                if (!String.IsNullOrEmpty(obj.Text))
                {
                    Custom_Step_Frame.BorderBrush = StringToSolidColorBrushConverter.Convert("#C2DBFF");
                    MainVM.CustomSteps = obj.Text;
                    if(MainVM.Step_Selected == null && String.IsNullOrEmpty(obj.Text))
                    {
                        Page_One_Next_Button.IsEnabled = false;
                    }
                    else
                    {
                        
                        Page_One_Next_Button.IsEnabled = true;
                    }
                }
                else
                {
                    Custom_Step_Frame.BorderBrush = StringToSolidColorBrushConverter.Convert("transparent");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Page_One_Next_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Page_One_Grid.Visibility = Visibility.Collapsed;
                Page_Two_Grid.Visibility = Visibility.Visible;
                foreach (var item in MainVM.Navigations)
                {
                    if (item.Text == "2")
                    {
                        item.Background = "#C2DBFF";
                    }
                    else
                    {
                        item.Background = "#363C46";
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Page Two Event Handlers - Below
        //___________________________________________________________________________________
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

        private void Day_TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBlock;
                var model = (Text_Button_DTO)obj.DataContext;
                if (model != null)
                {
                    var prev = MainVM.EachMonth.Where(x => x.DateTime == MainVM.SelectedTime).FirstOrDefault();
                    if (prev != null)
                    {
                        prev.Foreground = "#7D8CA8";
                    }
                    MainVM.EachMonth.Where(x => x.DateTime == model.DateTime).FirstOrDefault().Foreground = "#C2DBFF";
                    MainVM.SelectedTime = model.DateTime;
                }
                Page_Two_Save_Button.IsEnabled = true;
            }
            catch (Exception ex) { }
        }

        private void Status_Toggle_Frame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                if(Hide_Status_Frame.Visibility == Visibility.Collapsed)
                {
                    Hide_Status_Frame.Visibility = Visibility.Visible;
                    Display_Status_Frame.Visibility = Visibility.Collapsed;
                    Display_Status_TextBlock.Text = "Hide date on timeline";
                    Display_Status_TextBlock.Foreground = StringToSolidColorBrushConverter.Convert("#80FFFFFF");
                    MainVM.DisplayDate = false;
                }
                else
                {
                    Hide_Status_Frame.Visibility = Visibility.Collapsed;
                    Display_Status_Frame.Visibility = Visibility.Visible;
                    Display_Status_TextBlock.Text = "Display date on timeline";
                    Display_Status_TextBlock.Foreground = StringToSolidColorBrushConverter.Convert("#FAFFFFFF");
                    MainVM.DisplayDate = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TaskComplete_Yes_Button_Click(object sender, RoutedEventArgs e)
        {
            TaskComplete_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            TaskComplete_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
            TaskComplete_No_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
            TaskComplete_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            MainVM.TaskComplete = true;
            Page_Two_Save_Button.IsEnabled = true;
        }

        private void TaskComplete_No_Button_Click(object sender, RoutedEventArgs e)
        {
            TaskComplete_No_Button.Background = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            TaskComplete_No_Button.Foreground = StringToSolidColorBrushConverter.Convert("#313740");
            TaskComplete_Yes_Button.Background = StringToSolidColorBrushConverter.Convert("#313740");
            TaskComplete_Yes_Button.Foreground = StringToSolidColorBrushConverter.Convert("#C2DBFF");
            MainVM.TaskComplete = false;
            Page_Two_Save_Button.IsEnabled = true;
        }

        private async void Page_Two_Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.AddMidTask();
                var frame = Window.Current.Content as Frame;
                var main = frame.Content as MainBoard;
                var app = main.Main_Contents_Frame.Content as ApplicationsPage;
                app.New_Task_Popup.IsOpen = false;
                await app.BlurredBackgroundOpen(false);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
