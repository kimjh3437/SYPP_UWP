using SYPP.Model.DB.Components.Contents;
using SYPP.Utilities.Storage;
using SYPP.View.Components.UserControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SYPP.View.Components.UserControls
{
    public sealed partial class NotesUserControl : Windows.UI.Xaml.Controls.UserControl
    {
        public NoteUserControlViewModel MainVM;
        public NotesUserControl()
        {
            this.InitializeComponent();
        }
        //___________________________________________________________________________________
        //
        // Initial Handlers - Below
        //___________________________________________________________________________________
        public async Task InitializeDataContext()
        {
            if (this.DataContext == null)
            {
                MainVM = new NoteUserControlViewModel();
                //await MainVM.LoadMockData();
                this.DataContext = MainVM;
            }
            else if (this.DataContext != null)
            {
                MainVM = (NoteUserControlViewModel)this.DataContext;
            }
        }

        //___________________________________________________________________________________
        //
        // Notes Related Handlers - Below
        //___________________________________________________________________________________

        private void Note_Bullet_Icon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Note_NumberBullet_Icon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Note_Code_Icon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Note_Image_Icon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Note_Attachment_Icon_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Note_Content_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                var model = (Contents_Sub)obj.DataContext;
                if (model != null)
                {
                    model.Content = obj.Text;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void Note_Content_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                var obj = sender as TextBox;
                var model = (Contents_Sub)obj.DataContext;
                if (model != null)
                {
                    if (e.Key == Windows.System.VirtualKey.Back)
                    {
                        if (MainVM.Contents.Count != 1)
                        {
                            if (String.IsNullOrEmpty(obj.Text))
                            {
                                MainVM.Contents.Remove(model);
                            }
                        }
                        if (MainVM.Contents.Count == 1)
                        {
                            if (String.IsNullOrEmpty(obj.Text))
                            {
                                if (model.MarginType != 0)
                                    model.MarginType--;
                            }
                        }
                    }
                    if (e.Key == Windows.System.VirtualKey.Control)
                    {
                        var index = MainVM.Contents.IndexOf(model);
                        if (index >= MainVM.Contents.Count)
                        {
                            MainVM.Contents.Add(new Contents_Sub
                            {
                                noteContentsID = Guid.NewGuid().ToString(),
                                Content = "",
                                MarginType = model.MarginType
                            });
                        }
                        else
                        {
                            MainVM.Contents.Insert(index + 1, new Contents_Sub
                            {
                                noteContentsID = Guid.NewGuid().ToString(),
                                Content = "",
                                MarginType = model.MarginType
                            });
                        }
                    }

                    if (e.Key == Windows.System.VirtualKey.Shift)
                    {
                        model.MarginType--;
                        model.UpdateMargin();
                    }

                    if (e.Key == Windows.System.VirtualKey.Tab)
                    {
                        if (model.MarginType > 0)
                        {
                            model.MarginType++;
                            model.UpdateMargin();
                        }
                        else
                        {
                            var start = obj.SelectionStart;
                            obj.Text = $"{obj.Text.Substring(0, start)}   {obj.Text.Substring(start, obj.Text.Length - start)}";
                        }
                    }
                    if (e.Key == Windows.System.VirtualKey.Space)
                    {
                        if (model.MarginType == 0 && !String.IsNullOrEmpty(obj.Text))
                        {
                            var index = obj.SelectionStart;
                            var text = obj.Text.Replace(" ", "");
                            if (index < 2 && text.ElementAt<Char>(0) == '-')
                            {
                                var a = obj.Text.ElementAt<Char>(index - 1);
                                if (obj.Text.ElementAt<Char>(index - 1) == '-')
                                {
                                    obj.Text = obj.Text.Remove(0, 1);
                                    model.MarginType++;
                                    model.UpdateBulletVisibility();
                                    model.UpdateMargin();
                                }
                            }
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
        // File Handlers - Below
        //___________________________________________________________________________________

        private async void InputBox_Attached_File_Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                var obj = sender as Button;
                var model = (SYPP.Model.DB.Components.File.File)obj.DataContext;
                if (model != null)
                {
                    model.Preview_IsOpen = true;
                    if (model.ImageSource == null && model.Contents != null)
                    {
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {
                            using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                            {
                                writer.WriteBytes(model.Contents);
                                await writer.StoreAsync();
                            }
                            var image = new BitmapImage();
                            await image.SetSourceAsync(stream);
                            model.ImageSource = image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void InputBox_Attached_Image_Preview_Closed(object sender, object e)
        {
            var obj = sender as Popup;
            var model = (SYPP.Model.DB.Components.File.File)obj.DataContext;
            if (model != null)
                model.Preview_IsOpen = false;
        }

        private void InputBox_Attached_Image_Preview_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            var obj = sender as Popup;
            var model = (SYPP.Model.DB.Components.File.File)obj.DataContext;
            if (model != null)
                model.Preview_IsOpen = false;
        }

        private async void Notes_Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    for (var x = 0; x < items.Count; x++)
                    {
                        var file = items[x] as StorageFile;
                        var type = file.ContentType;
                        Byte[] sample;
                        using (var inputStream = await file.OpenSequentialReadAsync())
                        {
                            var readStream = inputStream.AsStreamForRead();
                            var byteArray = new byte[readStream.Length];
                            await readStream.ReadAsync(byteArray, 0, byteArray.Length);
                            sample = byteArray;
                            var file_n = new SYPP.Model.DB.Components.File.File
                            {
                                Contents = byteArray,
                                fileID = Guid.NewGuid().ToString(),
                                uID = LocalStorage.User.Personal.uID,
                                Title = $"{file.Name}",
                                UploadTime = DateTime.UtcNow
                            };
                            MainVM.Files.Add(file_n);
                            if (MainVM.Files.Count > 0)
                            {
                                Files_Attachments_GridView.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
        }

        private void Notes_Grid_DragOver(object sender, DragEventArgs e)
        {
            //To specifies which operations are allowed    
            e.AcceptedOperation = DataPackageOperation.Copy;
            // To display the data which is dragged    
            e.DragUIOverride.Caption = "drop here to view image";
            e.DragUIOverride.IsGlyphVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsCaptionVisible = true;
        }
    }
}
