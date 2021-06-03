using SYPP.Model.DB.Components.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Contacts
{
    public class Contact_Type
    {
        public string contactID { get; set; }
        public string Type { get; set; } // Email, Phone, ConvoNotes 
        public List<Contents_Sub> Contents { get; set; }
    }
}
