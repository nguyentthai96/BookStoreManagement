using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BookStoreManagementUW.Staffs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StaffInformation : Page
    {
        private BookStoreManagementData.Models.Staff staff;
        private byte[] imageStaff_m;
        public StaffInformation()
        {
            this.InitializeComponent();
            ImageStaff.Source= new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("/Assets/person.scale-200.png", UriKind.Relative));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            staff = new BookStoreManagementData.Models.Staff()
            {
                StaffName = StaffName.Text,
                Birthday = BirthdayStaff.Date.DateTime,
                PhoneNumber = PhoneNumber.Text,
                Address = Address.Text,
                Describe = Describe.Text,
                Gender = ((string)MaleRadioButton.Content == "Nam") ? true : false,
                Status = true,
                ImageStaff = imageStaff_m
            };

            var db = new BookStoreManagementData.BookStoreContext();
            db.Staff.Add(staff);
            db.SaveChanges();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
