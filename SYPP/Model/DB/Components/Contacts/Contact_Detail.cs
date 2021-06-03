using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Contacts
{
    public class Contact_Detail
    {
        public string contactID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string companyID { get; set; }
        public string applicationID { get; set; }
    }
}
