using SYPP.Model.DB.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> CreateTemplate(Template param);
        Task<Template> UpdateTemplate(Template param);
        Task<Template> Get(string templateID);
        Task<List<Template>> GetTemplates();
    }
}
