using BookStoreManagementData;
using BookStoreManagementData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace BookStoreManagementUW.Staffs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StaffInformation : Page
    {
        private int StaffID;
        private bool bAdd = true;
        private StorageFile file;
        BookStoreContext db;

        public StaffInformation()
        {
            this.InitializeComponent();
            Edit.Visibility = Visibility.Collapsed;
        }


        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.StaffName = StaffName.Text;
            staff.Birthday = BirthdayStaff.Date.DateTime;
            staff.PhoneNumber = PhoneNumber.Text;
            staff.Address = Address.Text;
            staff.Describe = Describe.Text;
            staff.Gender = ((string)MaleRadioButton.Content == "Nam") ? true : false;
            staff.Status = true;
            staff.ImageStaff = await ExtentionMethod.AsByteArray(file);

            db = new BookStoreManagementData.BookStoreContext();
            db.Staff.Add(staff);
            db.SaveChanges();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            uint phoneNumber;
            if (UInt32.TryParse(textBox.Text.Trim(), out phoneNumber) == false)
            {
                MessageDialog msgbox = new MessageDialog("Bạn cần nhập số điện thoại đúng định dạng");
                await msgbox.ShowAsync();
            }
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = db.Staff.ToList().SingleOrDefault(s => s.StaffID == this.StaffID);
            staff.StaffName = StaffName.Text;
            staff.Birthday = BirthdayStaff.Date.DateTime;
            staff.PhoneNumber = PhoneNumber.Text;
            staff.Address = Address.Text;
            staff.Describe = Describe.Text;
            staff.Gender = ((string)MaleRadioButton.Content == "Nam") ? true : false;
            staff.Status = true;
            staff.ImageStaff = await ExtentionMethod.AsByteArray(file);

            db.SaveChanges();
        }

        private async void ImageStaff_Tapped(object sender, TappedRoutedEventArgs e)
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

                    ImageStaff.Source = src;
                    AutomationProperties.SetName(ImageStaff, this.file.Name);
                }
                catch (Exception err)
                {
                    MessageDialog mesg = new MessageDialog("Tải ảnh thất bại" + err);
                    await mesg.ShowAsync();
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Type typeParam = e.Parameter.GetType();
            PropertyInfo pAdd = typeParam.GetProperty("bAdd");
            this.bAdd = (bool)pAdd.GetValue(e.Parameter, null);
            if (!this.bAdd)
            {
                PropertyInfo pStaffID = typeParam.GetProperty("StaffID");
                this.StaffID = (int)pStaffID.GetValue(e.Parameter, null);
            }
        }

        private async void StaffInformation_Loaded(object sender, RoutedEventArgs e)
        {
            file = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Images\person.png"));
            if (!this.bAdd)
            {
                db = new BookStoreContext();
                Staff staff = db.Staff.ToList().SingleOrDefault(s => s.StaffID == this.StaffID);
                StaffName.Text = staff.StaffName;
                MaleRadioButton.IsChecked = staff.Gender;
                BirthdayStaff.Date = staff.Birthday;
                PhoneNumber.Text = staff.PhoneNumber;
                Address.Text = staff.Address;
                Describe.Text = staff.Describe;
                ImageStaff.Source = staff.ImageStaff.AsBitmapImage();

                Add.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Visible;
            }
        }
    }
}