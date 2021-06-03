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
    public sealed partial class TemplateDetailedPage : Page
    {
        public TemplateDetailViewModel MainVM;
        public TemplateDetailedPage()
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
                MainVM = new TemplateDetailViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (TemplateDetailViewModel)this.DataContext;
            }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param = (TemplateDetailViewModel)e.Parameter;
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
                if (MainVM.CreatingTemplate)
                {
                    SaveOrCopy_Button.Content = "Create";
                }
                else
                {
                    SaveOrCopy_Button.Content = "Save";
                }
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

        private void Template_TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Template_Selected.Content.Content = obj.Text;
            }
        }

        private async void SaveOrCopy_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await MainVM.SaveTemplate();
                SaveOrCopy_Button.Content = "Save";
            }
            catch(Exception ex)
            {

            }
        }

        private void Title_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var obj = sender as TextBox;
            if (!String.IsNullOrEmpty(obj.Text))
            {
                MainVM.Template_Selected.Detail.Title = obj.Text;
            }
        }
    }
}
