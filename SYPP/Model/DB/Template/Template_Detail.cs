using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Template
{
    public class Template_Detail
    {
        public string templateID { get; set; }
        public string uID { get; set; }
        public string Title { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsFavorite { get; set; }
    }
}
