using BookStoreManagementData;
using BookStoreManagementData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStoreManagementUW.Books
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookInformation : Page
    {
        private StorageFile file;
        BookStoreContext db;
        public BookInformation()
        {
            this.InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            book.BookName = BookName.Text;
            book.AuthorBook = AuthorBook.Text;
            book.BookPrice = double.Parse(BookPrice.Text);
            book.BookCoverImage = await ExtentionMethod.AsByteArray(file);

            db = new BookStoreContext();
            db.Book.Add(book);
            db.SaveChanges();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void ImageBook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                //staff.ImageStaff = await file.AsByteArray();
                try
                {
                    BitmapImage src = new BitmapImage();
                    using (IRandomAccessStream stream = await this.file.OpenAsync(FileAccessMode.Read))
                    {
                        await src.SetSourceAsync(stream);
                    }

                    ImageBook.Source = src;
                    AutomationProperties.SetName(ImageBook, this.file.Name);
                }
                catch (Exception err)
                {
                    MessageDialog mesg = new MessageDialog("Tải ảnh thất bại" + err);
                    await mesg.ShowAsync();
                }
            }
        }

        private async void BookInformation_Loaded(object sender, RoutedEventArgs e)
        {
            file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Images\bookImage.png"));
            Add.Visibility = Visibility.Collapsed;
            //Edit.Visibility = Visibility.Visible;
        }
    }
}
