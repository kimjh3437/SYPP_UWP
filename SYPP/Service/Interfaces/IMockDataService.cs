using SYPP.Model.DB;
using SYPP.Model.DB.Companies;
using SYPP.Model.DB.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface IMockDataService
    {
        Task<User> GetUser();
        Task<List<Application>> GetApplications();
        Task<List<Company>> GetCompanies();
    }
}
