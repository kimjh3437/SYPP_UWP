using SYPP.Model.DB.Companies;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DTO.General.Button;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SYPP.Utilities.HubConnection;

namespace SYPP.ViewModel.CompanyVM
{
    public class CompanyDetailViewModel : BaseViewModel
    {
        public CompanyDetailViewModel()
        {

            //___________________________________________________________________________________
            //
            // Company Event Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Events_Update_Received", (companyID, eventID) => Company_Events_Update_EventHandler?.Invoke(companyID, eventID));
            Hubs.Connection.On<string, string>("Company_Events_Delete_Received", (companyID, eventID) => Company_Events_Delete_EventHandler?.Invoke(companyID, eventID));

            Company_Events_Update_EventHandler += Company_Events_Update_Received;
            Company_Events_Delete_EventHandler += Company_Events_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Note Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Notes_Update_Received", (companyID, noteID) => Company_Notes_Update_EventHandler?.Invoke(companyID, noteID));
            Hubs.Connection.On<string, string>("Company_Notes_Delete_Received", (companyID, noteID) => Company_Notes_Delete_EventHandler?.Invoke(companyID, noteID));

            Company_Notes_Update_EventHandler += Company_Notes_Update_Received;
            Company_Notes_Delete_EventHandler += Company_Notes_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Contact Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Contacts_Update_Received", (companyID, contactID) => Company_Contacts_Update_EventHandler?.Invoke(companyID, contactID));
            Hubs.Connection.On<string, string>("Company_Contacts_Delete_Received", (companyID, contactID) => Company_Contacts_Delete_EventHandler?.Invoke(companyID, contactID));

            Company_Contacts_Update_EventHandler += Company_Contacts_Update_Received;
            Company_Contacts_Delete_EventHandler += Company_Contacts_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company FollowUp Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_FollowUps_Update_Received", (companyID, followUpID) => Company_FollowUps_Update_EventHandler?.Invoke(companyID, followUpID));
            Hubs.Connection.On<string, string>("Company_FollowUps_Delete_Received", (companyID, followUpID) => Company_FollowUps_Delete_EventHandler?.Invoke(companyID, followUpID));

            Company_FollowUps_Update_EventHandler += Company_FollowUps_Update_Received;
            Company_FollowUps_Delete_EventHandler += Company_FollowUps_Delete_Received;

            //___________________________________________________________________________________
            //
            // Company Checklist Related Listeners- Below 
            //___________________________________________________________________________________
            Hubs.Connection.On<string, string>("Company_Checklists_Update_Received", (companyID, checklistID) => Company_Checklists_Update_EventHandler?.Invoke(companyID, checklistID));
            Hubs.Connection.On<string, string>("Company_Checklists_Delete_Received", (companyID, checklistID) => Company_Checklists_Delete_EventHandler?.Invoke(companyID, checklistID));

            Company_Checklists_Update_EventHandler += Company_Checklists_Update_Received;
            Company_Checklists_Delete_EventHandler += Company_Checklists_Delete_Received;
        }
        public async Task LoadData()
        {
            try
            {
                await InitializeComponents();
                await InitContentFilters();
                List<Task> Tasks = new List<Task>();
                Tasks.Add(LoadEvents());
                Tasks.Add(LoadContacts());
                Tasks.Add(LoadNotes());
                Tasks.Add(LoadConversations());
                Tasks.Add(LoadChecklist());

                await Task.WhenAll(Tasks);
            }
            catch(Exception ex)
            {

            }
        }
        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeComponents()
        {
            try
            {
                AddComponentsOptions = new ObservableCollection<Text_Button_DTO>();
                AddComponentsOptions.Add(new Text_Button_DTO
                {
                    Text = "Events",
                    Foreground = "#C2DBFF",
                    Background = "#363C46",
                    Background_Hover = "#339CC1F9",
                    IconSource = "/Assets/Navigations/Calendar_Navigation_UnSelected_Icon.svg",
                });
                AddComponentsOptions.Add(new Text_Button_DTO
                {
                    Text = "Notes",
                    Foreground = "#C2DBFF",
                    Background = "#363C46",
                    Background_Hover = "#339CC1F9",
                    IconSource = "/Assets/Navigations/Applications_Navigation_UnSelected_Icon.svg",
                });
                AddComponentsOptions.Add(new Text_Button_DTO
                {
                    Text = "Contacts",
                    Foreground = "#C2DBFF",
                    Background = "#363C46",
                    Background_Hover = "#339CC1F9",
                    IconSource = "/Assets/Components/Detailed/Contact_Icon.svg",
                });
                AddComponentsOptions.Add(new Text_Button_DTO
                {
                    Text = "Conversation Histories",
                    Foreground = "#C2DBFF",
                    Background = "#363C46",
                    Background_Hover = "#339CC1F9",
                    IconSource = "/Assets/Navigations/Templates_Navigation_UnSelected_Icon.svg",
                });
                AddComponentsOptions.Add(new Text_Button_DTO
                {
                    Text = "Checklists",
                    Foreground = "#C2DBFF",
                    Background = "#363C46",
                    Background_Hover = "#339CC1F9",
                    IconSource = "/Assets/Components/Detailed/Checklist_Icon.svg",
                });
            }
            catch (Exception ex)
            {

            }
        }
        public async Task InitContentFilters()
        {
            try
            {
                ContentFilters = new ObservableCollection<Text_Button_DTO>
                {
                    new Text_Button_DTO
                    {
                        Text = "All",
                        Background = "#C2DBFF",
                        Foreground = "#1E2127",
                        Background_Hover = "#DBEAFF",
                        Background_Pressed = "#E3EFFF",
                        IconSource = ""
                    },
                    new Text_Button_DTO
                    {
                        Icon_Height = 13,
                        Icon_Width = 12,
                        Text = "Events",
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5",
                        IconSource = "/Assets/Components/Detailed/Calendar_Icon.svg"
                    },
                    new Text_Button_DTO
                    {
                        Icon_Height = 12,
                        Icon_Width = 12,
                        Text = "Notes",
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5",
                        IconSource = "/Assets/Components/Detailed/Note_Icon.svg"
                    },
                    new Text_Button_DTO
                    {
                        Icon_Height = 12,
                        Icon_Width = 12,
                        Text = "Contacts",
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5",
                        IconSource = "/Assets/Components/Detailed/Contact_Icon.svg"
                    },
                    new Text_Button_DTO
                    {
                        Icon_Height = 12,
                        Icon_Width = 13,
                        Text = "Conversation Histories",
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5",
                        IconSource = "/Assets/Components/Detailed/Convo_Icon.svg"
                    },
                    new Text_Button_DTO
                    {
                        Icon_Height = 12,
                        Icon_Width = 14,
                        Text = "Checklists",
                        Background = "#363C46",
                        Foreground = "#C2DBFF",
                        Background_Hover = "#7D8CA8",
                        Background_Pressed = "#94A5C5",
                        IconSource = "/Assets/Components/Detailed/Checklist_Icon.svg"
                    }
                };
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task LoadEvents()
        {
            try
            {
                if (Company_Selected != null)
                {
                    Events = new ObservableCollection<Event>();
                    foreach (var note in Company_Selected.Events)
                    {
                        foreach (var item in note.Contents)
                        {

                        }
                        Events.Add(note);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task LoadNotes()
        {
            try
            {
                if (Company_Selected != null)
                {
                    Notes = new ObservableCollection<Note>();
                    foreach (var note in Company_Selected.Notes)
                    {
                        foreach (var item in note.Contents)
                        {
                            //if (!item.Header.Substring(0, 1).Equals("-"))
                            //{
                            //    item.Header = $"- {item.Header}";
                            //}

                            //var list = new List<Contents_Text>();
                            //foreach(var each in item.Contents)
                            //{
                            //    if (!each.Content.Substring(0,1).Equals("-"))
                            //    {
                            //        each.Content = $"- {each.Content}";
                            //        list.Add(each);
                            //    }
                            //    else
                            //    {
                            //        list.Add(each);
                            //    }
                            //}
                            //item.Contents = list;
                        }
                        Notes.Add(note);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task LoadContacts()
        {
            try
            {
                if (Company_Selected != null)
                {
                    Contacts = new ObservableCollection<Contact>();
                    foreach (var contact in Company_Selected.Contacts)
                    {
                        contact.Contacts = new ObservableCollection<Text_Button_DTO>
                        {
                            new Model.DTO.General.Button.Text_Button_DTO
                            {
                                correspondenceID= contact.contactID,
                                IconSource = "/Assets/Components/Detailed/Mail_Selected_Icon.svg",
                                Text = contact.Email.Email,
                                Background = "#C2DBFF",
                                Foreground = "#242931",
                                Background_Hover = "#DBEAFF",
                                Background_Pressed = "#E3EFFF"
                            },
                            new Model.DTO.General.Button.Text_Button_DTO
                            {
                                correspondenceID= contact.contactID,
                                IconSource = "/Assets/Components/Detailed/Phone_UnSelected_Icon.svg",
                                Text = contact.Phone.PhoneNumber,
                                Background = "#5E6A7E",
                                Foreground = "#242931",
                                Background_Hover = "#7D8CA8",
                                Background_Pressed = "#94A5C5"
                            },
                            new Model.DTO.General.Button.Text_Button_DTO
                            {
                                correspondenceID= contact.contactID,
                                IconSource = "/Assets/Components/Detailed/Contact_Note_UnSelected_Icon.svg",
                                Text = "Text",
                                Background = "#5E6A7E",
                                Foreground = "#242931",
                                Background_Hover = "#7D8CA8",
                                Background_Pressed = "#94A5C5"
                            }
                        };
                        contact.Contacts_Selected = new Model.DTO.General.Button.Text_Button_DTO
                        {
                            Text = contact.Email.Email,
                            Background = "#C2DBFF",
                            Foreground = "#242931",
                            Background_Hover = "#DBEAFF",
                            Background_Pressed = "#E3EFFF"
                        };
                        foreach (var item in contact.Convo)
                        {
                            //if(!item.Header.Substring(0, 1).Equals("-"))
                            //{
                            //    item.Header = $"- {item.Header}";
                            //}
                            //var list = new List<Contents_Text>();
                            //foreach (var each in item.Contents)
                            //{
                            //    if (!each.Content.Substring(0, 1).Equals("-"))
                            //    {
                            //        each.Content = $"- {each.Content}";
                            //        list.Add(each);
                            //    }
                            //    else
                            //    {
                            //        list.Add(each);
                            //    }
                            //}
                            //item.Contents = list;
                        }
                        Contacts.Add(contact);
                    }
                }
            }
            catch (Exception ex) { }
        }
        public async Task LoadConversations()
        {
            try
            {
                if (Company_Selected != null)
                {
                    FollowUps = new ObservableCollection<FollowUp>();
                    foreach (var convo in Company_Selected.FollowUps)
                    {
                        foreach (var item in convo.Description)
                        {
                            //if (!item.Header.Substring(0, 1).Equals("-"))
                            //{
                            //    item.Header = $"- {item.Header}";
                            //}
                            //var list = new List<Contents_Text>();
                            //foreach (var each in item.Contents)
                            //{
                            //    if (!each.Content.Substring(0, 1).Equals("-"))
                            //    {
                            //        each.Content = $"- {each.Content}";
                            //        list.Add(each);
                            //    }
                            //    else
                            //    {
                            //        list.Add(each);
                            //    }
                            //}
                            //item.Contents = list;
                        }
                        FollowUps.Add(convo);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task LoadChecklist()
        {
            try
            {
                if (Company_Selected != null)
                {
                    Checklists = new ObservableCollection<Checklist>(Company_Selected.Checklists);
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
        public Company Company_Selected { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Text_Button_DTO> ContentFilters { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<FollowUp> FollowUps { get; set; }
        public ObservableCollection<Checklist> Checklists { get; set; }
        public ObservableCollection<Text_Button_DTO> AddComponentsOptions { get; set; }


        //___________________________________________________________________________________
        //
        // Company Event Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Events_Update_Received(string companyID, string eventID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;

                var company_component = await _company.GetEvent(companyID, eventID);
                if (company_component == null)
                    return;

                if(Events.Where(x => x.eventID == eventID).Any())
                {
                    var item = Events.Where(x => x.Detail.eventID == eventID).FirstOrDefault();
                    var index = Events.IndexOf(item);
                    Events.RemoveAt(index);
                    Events.Insert(index, company_component);
                }
                else
                {
                    Events.Add(company_component);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Events_Delete_Received(string companyID, string eventID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;
                Events.Remove(Events.Where(X => X.eventID == eventID).FirstOrDefault());
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Note Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Notes_Update_Received(string companyID, string noteID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;

                var company_component = await _company.GetNote(companyID, noteID);
                if (company_component == null)
                    return;

                if (Notes.Where(x => x.noteID == noteID).Any())
                {
                    var item = Notes.Where(x => x.Detail.noteID == noteID).FirstOrDefault();
                    var index = Notes.IndexOf(item);
                    Notes.RemoveAt(index);
                    Notes.Insert(index, company_component);
                }
                else
                {
                    Notes.Add(company_component);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Notes_Delete_Received(string companyID, string noteID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;
                Notes.Remove(Notes.Where(X => X.noteID == noteID).FirstOrDefault());
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Contact Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Contacts_Update_Received(string companyID, string contactID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;

                var company_component = await _company.GetContact(companyID, contactID);
                if (company_component == null)
                    return;

                if (Contacts.Where(x => x.contactID == contactID).Any())
                {
                    var item = Contacts.Where(x => x.Detail.contactID == contactID).FirstOrDefault();
                    var index = Contacts.IndexOf(item);
                    Contacts.RemoveAt(index);
                    Contacts.Insert(index, company_component);
                }
                else
                {
                    Contacts.Add(company_component);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Contacts_Delete_Received(string companyID, string contactID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;
                Contacts.Remove(Contacts.Where(X => X.contactID == contactID).FirstOrDefault());
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company FollowUp Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_FollowUps_Update_Received(string companyID, string followUpID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;

                var company_component = await _company.GetFollowUp(companyID, followUpID);
                if (company_component == null)
                    return;

                if (FollowUps.Where(x => x.followUpID == followUpID).Any())
                {
                    var item = FollowUps.Where(x => x.Detail.followUpID == followUpID).FirstOrDefault();
                    var index = FollowUps.IndexOf(item);
                    FollowUps.RemoveAt(index);
                    FollowUps.Insert(index, company_component);
                }
                else
                {
                    FollowUps.Add(company_component);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_FollowUps_Delete_Received(string companyID, string followUpID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;
                FollowUps.Remove(FollowUps.Where(X => X.followUpID == followUpID).FirstOrDefault());
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Company Checklist Related Listeners- Below 
        //___________________________________________________________________________________
        public async void Company_Checklists_Update_Received(string companyID, string checklistID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;

                var company_component = await _company.GetChecklist(companyID, checklistID);
                if (company_component == null)
                    return;

                if (Checklists.Where(x => x.checklistID == checklistID).Any())
                {
                    var item = Checklists.Where(x => x.checklistID == checklistID).FirstOrDefault();
                    var index = Checklists.IndexOf(item);
                    Checklists.RemoveAt(index);
                    Checklists.Insert(index, company_component);
                }
                else
                {
                    Checklists.Add(company_component);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void Company_Checklists_Delete_Received(string companyID, string checklistID)
        {
            try
            {
                if (Company_Selected.companyID != companyID)
                    return;
                Checklists.Remove(Checklists.Where(X => X.checklistID == checklistID).FirstOrDefault());
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        // /////////////////////////////////////////////////////////////////////////////////
        // Event Handlers BELOW 
        // /////////////////////////////////////////////////////////////////////////////////
        //___________________________________________________________________________________
        //company related below 
        public event Action<string, string> Company_Events_Update_EventHandler;
        public event Action<string, string> Company_Events_Delete_EventHandler;
        public event Action<string, string> Company_Notes_Update_EventHandler;
        public event Action<string, string> Company_Notes_Delete_EventHandler;
        public event Action<string, string> Company_Contacts_Update_EventHandler;
        public event Action<string, string> Company_Contacts_Delete_EventHandler;
        public event Action<string, string> Company_FollowUps_Update_EventHandler;
        public event Action<string, string> Company_FollowUps_Delete_EventHandler;
        public event Action<string, string> Company_Checklists_Update_EventHandler;
        public event Action<string, string> Company_Checklists_Delete_EventHandler;
    }
}
