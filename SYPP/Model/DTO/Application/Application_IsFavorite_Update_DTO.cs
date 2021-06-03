using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DTO.Application
{
    public class Application_IsFavorite_Update_DTO
    {
        public string applicationID { get; set; }
        public bool IsFavorite { get; set; }
    }
}
