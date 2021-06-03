using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DTO.Company
{
    public class Company_IsFavorite_Update_DTO
    {
        public string companyID { get; set; }
        public bool IsFavorite { get; set; }
    }
}
