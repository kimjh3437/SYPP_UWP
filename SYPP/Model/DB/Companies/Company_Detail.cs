using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Model.DB.Companies
{
    public class Company_Detail
    {
        public string companyID { get; set; }
        public string uID { get; set; }
        public string CompanyName { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime SubmittedTime { get; set; }
    }
}
