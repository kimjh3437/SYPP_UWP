using SYPP.Model.DB.Components.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Checklists
{
    public class Checklist
    {
        public string checklistID { get; set; }
        public string companyID { get; set; }
        public string applicationID { get; set; }
        public string Type { get; set; }
        public bool Submission { get; set; }
        public List<Checklist_Option> Options { get; set; }
        public List<Contents_Sub> Notes { get; set; }
        public List<SYPP.Model.DB.Components.File.File> Files { get; set; }
    }
}
