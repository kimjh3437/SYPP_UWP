using SYPP.Model.DB.User;
using SYPP.Model.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface IAuthService
    {
        Task<User> Authenticate(User_Authenticate_DTO authenticate);

        Task<User> Register(User_Register_DTO register);

        Task<bool> NameCheck(string username);
    }
}
