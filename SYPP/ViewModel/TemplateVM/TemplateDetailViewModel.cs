using SYPP.Model.DB.Template;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.TemplateVM
{
    public class TemplateDetailViewModel : BaseViewModel
    {
        public TemplateDetailViewModel()
        {

        }

        public async Task LoadData()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task SaveTemplate()
        {
            try
            {
                if (CreatingTemplate)
                {
                    if (Template_Selected != null)
                    {
                        var output = await _template.CreateTemplate(Template_Selected);
                        if (output != null)
                        {
                            await _socket.Template_Create_Init(output.templateID);
                        }
                        CreatingTemplate = false;
                    }
                }
                else
                {
                    if (Template_Selected != null)
                    {
                        var output = await _template.UpdateTemplate(Template_Selected);
                        if (output != null)
                        {
                            await _socket.Template_Update_Init(output.templateID, false);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________
        public Template Template_Selected { get; set; }
        public bool CreatingTemplate { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
    }
}
