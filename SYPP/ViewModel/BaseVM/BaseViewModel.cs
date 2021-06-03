using SYPP.Service.Container;
using SYPP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.BaseVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ITemplateService _template;
        public IAuthService _auth;
        public ICompanyService _company;
        public IMockDataService _mock;
        public IApplicationService _applicaiton;
        public ISignalRSocketHubService _socket;
        public IFileService _file;
        public BaseViewModel()
        {
            _template = ServiceContainer.Get<ITemplateService>();
            _file = ServiceContainer.Get<IFileService>();
            _applicaiton = ServiceContainer.Get<IApplicationService>();
            _company = ServiceContainer.Get<ICompanyService>();
            _mock = ServiceContainer.Get<IMockDataService>();
            _auth = ServiceContainer.Get<IAuthService>();
            _socket = ServiceContainer.Get<ISignalRSocketHubService>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

//___________________________________________________________________________________
//
// Template Methods
//___________________________________________________________________________________
//public async void Template_Listener(object param1, object param2)
//{
//    try
//    {

//    }
//    catch (Exception ex)
//    {
//        Console.Write($"<MethodName> : {ex}");
//    }
//}
//public async Task Template_Init(object param1, object param2)
//{
//    try
//    {

//    }
//    catch (Exception ex)
//    {
//        Console.Write($"<MethodName> : {ex}");
//    }
//}

//___________________________________________________________________________________
//
// Initial Handlers - Below
//___________________________________________________________________________________

//___________________________________________________________________________________
//
// Event Handlers - Below
//___________________________________________________________________________________


//___________________________________________________________________________________
//
// Binding Models - Below
//___________________________________________________________________________________


//___________________________________________________________________________________
//
// Observable Collections - Below
//___________________________________________________________________________________
