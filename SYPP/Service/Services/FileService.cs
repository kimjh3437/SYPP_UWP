using Newtonsoft.Json;
using SYPP.Model.DTO.Primitives;
using SYPP.Service.Interfaces;
using SYPP.Utilities.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service
{
    public class FileService : IFileService
    {
        HttpClient client;
        public FileService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{Configuration.BackendURL}");
        }
        public async Task<byte[]> GetFileSource(string fileID)
        {
            if (fileID != null)
            {
                var response = await client.GetAsync($"/files/get/{fileID}");
                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsStringAsync();
                    var output = JsonConvert.DeserializeObject<byte[]>(temp);
                    return output;
                }
                return null;
            }
            return null;
        }
    }
}
