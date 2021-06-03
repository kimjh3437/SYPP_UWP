using SYPP.Model.DB.Components.Contents;
using SYPP.ViewModel.BaseVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace SYPP.ViewModel.ComponentsVM.Note
{
    public class NoteDetailedViewModel : BaseViewModel
    {
        public NoteDetailedViewModel()
        {
            

        }

        public async Task LoadData()
        {
            try
            {
                await InitializeModels();
                LoadFiles();
            }
            catch (Exception ex)
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
                Contents = new ObservableCollection<Contents_Sub>();
                Files = new ObservableCollection<Model.DB.Components.File.File>();

                if (CreatingNewNote)
                {
                    Note = new Model.DB.Components.Notes.Note
                    {
                        Detail = new Model.DB.Components.Notes.Note_Detail { }
                    };
                    Contents.Add(new Contents_Sub
                    {
                        noteContentsID = Guid.NewGuid().ToString(),
                        MarginType = 0
                    });
                }
                else
                {
                    foreach(var item in Note.Contents)
                    {
                        Contents.Add(item);
                    }
                    Title = Note.Detail.Title;
                }
               
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async void LoadFiles()
        {
            try
            {
                Files.Clear();
                if (Note != null && Note.Files != null)
                {
                    foreach (var item in Note.Files)
                    {
                        item.Preview_IsOpen = false;
                        item.Contents = await _file.GetFileSource(item.fileID);
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {
                            using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                            {
                                writer.WriteBytes(item.Contents);
                                await writer.StoreAsync();
                            }
                            var image = new BitmapImage();
                            await image.SetSourceAsync(stream);
                            item.ImageSource = image;
                        }
                        Files.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task SaveNote()
        {
            //var id = 0;
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (CreatingNewNote)
                    {
                        SYPP.Model.DB.Components.Notes.Note Note = new SYPP.Model.DB.Components.Notes.Note
                        {
                            noteID = "",
                            Detail = new Model.DB.Components.Notes.Note_Detail
                            {
                                companyID = companyID,
                                noteID = "",
                                Title = Title,
                                Time = DateTime.UtcNow
                            },
                            Contents = Contents.ToList(),
                            Files = Files.ToList()
                        };
                        var output = await _company.CreateCompanyNote(Note);
                        if(output != null)
                        {
                            await _socket.Company_Notes_Update_Init(companyID, output.Detail.noteID);
                        }
                    }
                    else
                    {
                        SYPP.Model.DB.Components.Notes.Note Note = new SYPP.Model.DB.Components.Notes.Note
                        {
                            noteID = "",
                            Detail = new Model.DB.Components.Notes.Note_Detail
                            {
                                applicationID = applicationID,
                                noteID = "",
                                Title = Title,
                                Time = DateTime.UtcNow
                            },
                            Contents = Contents.ToList(),
                            Files = Files.ToList()
                        };
                        var output = await _company.UpdateCompanyNote(Note);
                        if(output != null)
                        {
                            await _socket.Company_Notes_Update_Init(companyID, output.Detail.noteID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (CreatingNewNote)
                    {
                        SYPP.Model.DB.Components.Notes.Note Note = new SYPP.Model.DB.Components.Notes.Note
                        {
                            noteID = "",
                            Detail = new Model.DB.Components.Notes.Note_Detail
                            {
                                companyID = companyID,
                                noteID = "",
                                Title = Title,
                                Time = DateTime.UtcNow
                            },
                            Contents = Contents.ToList(),
                            Files = Files.ToList()
                        };
                        var output = await _applicaiton.CreateApplicationNote(Note);
                        if(output != null)
                        {
                            await _socket.Application_Notes_Update_Init(companyID, output.Detail.noteID);
                        }
                    }
                    else
                    {
                        SYPP.Model.DB.Components.Notes.Note Note = new SYPP.Model.DB.Components.Notes.Note
                        {
                            noteID = "",
                            Detail = new Model.DB.Components.Notes.Note_Detail
                            {
                                applicationID = applicationID,
                                noteID = "",
                                Title = Title,
                                Time = DateTime.UtcNow
                            },
                            Contents = Contents.ToList(),
                            Files = Files.ToList()
                        };
                        var output = await _applicaiton.UpdateApplicationNote(Note);
                        if(output != null)
                        {
                            await _socket.Application_Notes_Update_Init(applicationID, output.Detail.noteID);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteNote()
        {
            try
            {
                if (!String.IsNullOrEmpty(companyID))
                {
                    if (!CreatingNewNote)
                    {
                        var result = await _company.DeleteCompanyNote(companyID, Note.Detail.noteID);
                        if (result)
                        {
                            await _socket.Company_Notes_Delete_Init(companyID, Note.Detail.noteID);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(applicationID))
                {
                    if (!CreatingNewNote)
                    {
                        var result = await _applicaiton.DeleteApplicationNote(applicationID, Note.Detail.noteID);
                        if (result)
                        {
                            await _socket.Application_Notes_Delete_Init(applicationID, Note.Detail.noteID);
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
        public SYPP.Model.DB.Components.Notes.Note Note { get; set; }
        public string Title { get; set; }
        public bool CreatingNewNote { get; set; }
        public string applicationID { get; set; }
        public string companyID { get; set; }

        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Contents_Sub> Contents { get; set; }
        public ObservableCollection<SYPP.Model.DB.Components.File.File> Files { get; set; }
    }
}
