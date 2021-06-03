using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Components.Texts
{
    public class Contents_Text : BaseModel.BaseModel
    {
        public string textID { get; set; }
        public string noteContentsID { get; set; }
        public string belongingID { get; set; } // noteID, eventID, etc 
        public string Content { get; set; }
    }
}
