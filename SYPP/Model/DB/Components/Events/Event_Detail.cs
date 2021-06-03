using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Events
{
    public class Event_Detail
    {
        public string eventID { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
    }
}
