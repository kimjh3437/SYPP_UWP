using SYPP.Model.DB.Components.Checklists;
using SYPP.View.Components.UserControl;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ComponentsVM.Checklist
{
    public class ChecklistDetailedViewModel : BaseViewModel 
    {
        public ChecklistDetailedViewModel()
        {

        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeModels()
        {
            try
            {
                NoteVM = new NoteUserControlViewModel();
                await NoteVM.LoadData();
                if (Checklist != null && Checklist.Notes != null && Checklist.Notes.Count != 0)
                {
                    NoteVM.Contents = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.Contents.Contents_Sub>(Checklist.Notes);
                }
                else
                {
                    await NoteVM.LoadInitElementContents();
                }
                if (Checklist != null && Checklist.Files != null && Checklist.Files.Count != 0)
                {
                    NoteVM.Files = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.File.File>(Checklist.Files);
                }
                NoteVM.LoadFiles();

                if (CreatingNewChecklist)
                {
                    Checklist = new Model.DB.Components.Checklists.Checklist
                    {
                        applicationID = applicationID,             
                        companyID = companyID,
                        Type = "",
                        Submission = false,
                        Options = new List<Model.DB.Components.Checklists.Checklist_Option>
                        {
                            new Checklist_Option
                            {
                                checklistID = "default",
                                checkOptionID = "default",
                                Content = "",
                                IsChecked = false
                            }
                        }
                    };
                    Options = new ObservableCollection<Checklist_Option>
                    {

                    };
                }
                else
                {
                    Options = new ObservableCollection<Checklist_Option>(Checklist.Options);
                }
                if(Options.Count == 0)
                {
                    Options.Add(
                        new Checklist_Option
                        {
                            checklistID = "default",
                            checkOptionID = "default",
                            Content = "",
                            IsChecked = false
                        });
                }
            }
            catch(Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task SaveChecklist()
        {
            try
            {
                Checklist.Notes = NoteVM.Contents.ToList();
                Checklist.Files = NoteVM.Files.ToList();
                Checklist.applicationID = applicationID;
                Checklist.Options = Options.ToList();
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (CreatingNewChecklist)
                    {
                        var output = await _company.CreateCompanyChecklist(Checklist);
                        if (output != null)
                        {
                            await _socket.Company_Checklists_Update_Init(companyID, output.checklistID);
                        }
                    }
                    else
                    {
                        var output = await _company.UpdateCompanyChecklist(Checklist);
                        if (output != null)
                        {
                            await _socket.Company_Checklists_Update_Init(applicationID, output.checklistID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {            
                    if (CreatingNewChecklist)
                    {
                        var output = await _applicaiton.CreateApplicationChecklist(Checklist);
                        if (output != null)
                        {
                            await _socket.Application_Checklists_Update_Init(applicationID, output.checklistID);
                        }
                    }
                    else
                    {
                        var output = await _applicaiton.UpdateApplicationChecklist(Checklist);
                        if(output != null)
                        {
                            await _socket.Application_Checklists_Update_Init(applicationID, output.checklistID);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteChecklist()
        {
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (!CreatingNewChecklist)
                    {
                        var output = await _company.DeleteCompanyChecklist(companyID, Checklist.checklistID);
                        if (output)
                        {
                            await _socket.Company_Checklists_Delete_Init(companyID, Checklist.checklistID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (!CreatingNewChecklist)
                    {
                        var output = await _applicaiton.DeleteApplicationChecklist(applicationID, Checklist.checklistID);
                        if (output)
                        {
                            await _socket.Application_Checklists_Delete_Init(applicationID, Checklist.checklistID);
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
        public NoteUserControlViewModel NoteVM { get; set; }
        public SYPP.Model.DB.Components.Checklists.Checklist Checklist { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public bool CreatingNewChecklist{ get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Checklist_Option> Options { get; set; }
    }
}
