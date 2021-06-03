using Microsoft.AspNetCore.SignalR.Client;
using SYPP.Converter.ColorConverter;
using SYPP.Service;
using SYPP.Service.Container;
using SYPP.Service.Interfaces;
using SYPP.Service.Services;
using SYPP.Service.Socket;
using SYPP.Utilities.Configurations;
using SYPP.Utilities.HubConnection;
using SYPP.Utilities.Storage;
using SYPP.View.Auth.SignIn;
using SYPP.View.Main;
using SYPP.ViewModel.AuthVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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

namespace SYPP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        public async Task RegisterServices()
        {
            ServiceContainer.Register<IMockDataService>(() => new MockDataService());

            ServiceContainer.Register<IAuthService>(() => new AuthService());

            ServiceContainer.Register<IApplicationService>(() => new ApplicationService());

            ServiceContainer.Register<ICompanyService>(() => new CompanyService());

            ServiceContainer.Register<ISignalRSocketHubService>(() => new SignalRSocketHubService());

            ServiceContainer.Register<IFileService>(() => new FileService());

            ServiceContainer.Register<ITemplateService>(() => new TemplateService());

            try
            {
                Hubs.Connection = new HubConnectionBuilder()
                .WithUrl(Configuration.SignalRURL)
                .WithAutomaticReconnect()
                .Build();
            }
            catch(Exception ex)
            {

            }
            //await socket.StartConnection();
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
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    LocalStorage.IsMock = false;

                    await RegisterServices();

                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    var SignInVM = new SignInViewModel();
                    await SignInVM.LoadData();
                    rootFrame.Navigate(typeof(SignInPage), SignInVM); // e.Arguments);
                    await SetTitleBarColors();
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
