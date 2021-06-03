using SYPP.Model.DB;
using SYPP.Model.DB.Companies;
using SYPP.Model.DB.Template;
using SYPP.Model.DB.User;
using SYPP.Model.DTO.Calendar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Utilities.Storage
{
    public static class LocalStorage
    {
        //___________________________________________________________________________________
        //
        // Basic Information - Below
        //___________________________________________________________________________________
        public static User User { get; set; }
        public static ObservableCollection<Application> Applications { get; set; }
        public static ObservableCollection<Company> Companies { get; set; }
        public static ObservableCollection<Template> Templates { get; set; }

        //___________________________________________________________________________________
        //
        // Calendar Handlers - Below
        //___________________________________________________________________________________
        public static DateTime Start { get; set; }
        public static DateTime End { get; set; }
        public static ObservableCollection<Daily_Tasks_DTO> Calendar { get; set; }

        //___________________________________________________________________________________
        //
        // Model Handlers - Below
        //___________________________________________________________________________________
        public static bool IsMock { get; set; }


        //___________________________________________________________________________________
        //
        // Coordinate Handlers - Below
        //___________________________________________________________________________________
        public static int Coordinate { get; set; }

        // 10 = Calendar Page 
        // 20 = Applications Page 
        // 30 = Companies Page 
        // 40 = Templates Page 


    }
}
