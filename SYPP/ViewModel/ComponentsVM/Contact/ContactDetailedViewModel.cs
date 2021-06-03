using SYPP.View.Components.UserControl;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.ViewModel.ComponentsVM.Contact
{
    public class ContactDetailedViewModel : BaseViewModel
    {
        public ContactDetailedViewModel()
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
                if (Contact != null && Contact.Convo != null && Contact.Convo.Count != 0)
                {
                    NoteVM.Contents = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.Contents.Contents_Sub>(Contact.Convo);
                }
                else
                {
                    await NoteVM.LoadInitElementContents();
                }
                if(Contact != null && Contact.Files != null && Contact.Files.Count != 0)
                {
                    NoteVM.Files = new System.Collections.ObjectModel.ObservableCollection<Model.DB.Components.File.File>(Contact.Files);
                }
                NoteVM.LoadFiles();
                
                if (CreatingNewContact)
                {
                    Contact = new Model.DB.Components.Contacts.Contact
                    {
                        contactID = "",
                        Phone = new Model.DB.Components.Contacts.Contact_Phone
                        {
                            PhoneNumber = ""
                        },
                        Email = new Model.DB.Components.Contacts.Contact_Email
                        {
                            Email = ""
                        },
                        Detail = new Model.DB.Components.Contacts.Contact_Detail
                        {
                            companyID = companyID,
                            applicationID = applicationID,
                            Firstname = "",
                            Lastname = "",
                            Company = "",
                            Title = ""
                        }
                    };
                }
                else
                {

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
        public async Task SaveContact()
        {
            try
            {
                if (NoteVM != null)
                {
                    Contact.Convo = NoteVM.Contents.ToList();
                    Contact.Files = NoteVM.Files.ToList();
                }
                Contact.Detail.applicationID = applicationID;
                Contact.Detail.companyID = companyID;
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (CreatingNewContact)
                    {
                        var output = await _company.CreateCompanyContact(Contact);
                        if (output != null)
                        {
                            await _socket.Company_Contacts_Update_Init(companyID, output.contactID);
                        }
                    }
                    else
                    {
                        var output = await _company.UpdateCompanyContact(Contact);
                        if (output != null)
                        {
                            await _socket.Company_Contacts_Update_Init(companyID, output.contactID);
                        }
                    }
                }

                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (CreatingNewContact)
                    {
                        var output = await _applicaiton.CreateApplicationContact(Contact);
                        if (output != null)
                        {
                            await _socket.Application_Contacts_Update_Init(applicationID, output.contactID);
                        }
                    }
                    else
                    {
                        var output = await _applicaiton.UpdateApplicationContact(Contact);
                        if (output != null)
                        {
                            await _socket.Application_Contacts_Update_Init(applicationID, output.contactID);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteContact()
        {
            try
            {
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (!CreatingNewContact)
                    {
                        var output = await _applicaiton.DeleteApplicationContact(applicationID, Contact.contactID);
                        if (output)
                        {
                            await _socket.Application_Contacts_Delete_Init(applicationID, Contact.contactID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (!CreatingNewContact)
                    {
                        var output = await _company.DeleteCompanyContact(companyID, Contact.contactID);
                        if (output)
                        {
                            await _socket.Company_Contacts_Delete_Init(companyID, Contact.contactID);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
        }


        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________

        public NoteUserControlViewModel NoteVM { get; set; }
        public SYPP.Model.DB.Components.Contacts.Contact Contact { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }
        public bool CreatingNewContact { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________

    }
}
