using SYPP.Model.DB;
using SYPP.Model.DB.Components.Checklists;
using SYPP.Model.DB.Components.Contacts;
using SYPP.Model.DB.Components.Events;
using SYPP.Model.DB.Components.FollowUp;
using SYPP.Model.DB.Components.Notes;
using SYPP.Model.DB.Components.Texts;
using SYPP.Model.DTO.General.Button;
using SYPP.Utilities.HubConnection;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SYPP.ViewModel.ApplicationVM
{
    public class ApplicationDetailViewModel : BaseViewModel
    {
        public ApplicationDetailViewModel()
        {
            

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
            catch(Exception ex)
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
            catch(Exception ex)
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
                if(Application_Selected != null)
                {
                    Events = new ObservableCollection<Event>();
                    foreach (var note in Application_Selected.Events)
                    {
                        foreach (var item in note.Contents)
                        {
                          
                        }
                        Events.Add(note);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public async Task LoadNotes()
        {
            try
            {
                if (Application_Selected != null)
                {
                    Notes = new ObservableCollection<Note>();
                    foreach (var note in Application_Selected.Notes)
                    {
                        foreach(var item in note.Contents)
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
                if (Application_Selected != null)
                {
                    Contacts = new ObservableCollection<Contact>();
                    foreach(var contact in Application_Selected.Contacts)
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
                        foreach(var item in contact.Convo)
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
            catch(Exception ex) { }
        }
        public async Task LoadConversations()
        {
            try
            {
                if (Application_Selected != null)
                {
                    FollowUps = new ObservableCollection<FollowUp>();
                    foreach(var convo in Application_Selected.FollowUps)
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
            catch(Exception ex)
            {

            }
        }
        public async Task LoadChecklist()
        {
            try
            {
                if (Application_Selected != null)
                {
                    Checklists = new ObservableCollection<Checklist>(Application_Selected.Checklists);
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
        public Application Application_Selected { get; set; }


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



        
    }
}
