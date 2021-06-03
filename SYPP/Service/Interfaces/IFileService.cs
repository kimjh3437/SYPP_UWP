using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> GetFileSource(string fileID);
    }
}
