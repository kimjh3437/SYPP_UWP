using SYPP.Model.DB.Components.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.FollowUp
{
    public class FollowUp_Detail
    {
        public string followUpID { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public DateTime Time { get; set; }
        public Contact_Detail Personnel { get; set; }
    }
}
