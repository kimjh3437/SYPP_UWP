using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.FollowUp
{
    public class FollowUp
    {
        public string followUpID { get; set; }
        public FollowUp_Detail Detail { get; set; }
        public List<Contents_Sub> Description { get; set; }
        public List<SYPP.Model.DB.Components.File.File> Files { get; set; }
    }
}
