using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Notes
{
    public class Note_Detail
    {
        public string noteID { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }
    }
}
