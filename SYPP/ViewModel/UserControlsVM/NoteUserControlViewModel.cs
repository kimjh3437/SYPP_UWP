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

namespace SYPP.View.Components.UserControl
{
    public class NoteUserControlViewModel : BaseViewModel
    {
        public NoteUserControlViewModel()
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
                Contents = new ObservableCollection<Contents_Sub>();
                Files = new ObservableCollection<Model.DB.Components.File.File>();
            }
            catch (Exception ex)
            {

            }
        }

        //___________________________________________________________________________________
        //
        // Event Handlers - Below
        //___________________________________________________________________________________
        public async Task LoadInitElementContents()
        {
            try
            {
                Contents.Add(new Contents_Sub
                {
                    Content = "",
                    MarginType = 0
                });
            }
            catch(Exception ex)
            {

            }
        }
        public async void LoadFiles()
        {
            try
            {
                if (Files != null)
                {
                    foreach (var item in Files)
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


        //___________________________________________________________________________________
        //
        // Binding Models - Below
        //___________________________________________________________________________________


        //___________________________________________________________________________________
        //
        // Observable Collections - Below
        //___________________________________________________________________________________
        public ObservableCollection<Contents_Sub> Contents { get; set; }
        public ObservableCollection<SYPP.Model.DB.Components.File.File> Files { get; set; }
    }
}
