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
    public sealed partial class RightStaff : Page
    {
        public RightStaff()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                RightStaffs.ItemsSource = db.Right.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                BookStoreManagementData.Models.CustomModels.Right RightStaff = new BookStoreManagementData.Models.CustomModels.Right
                    { RightName = RightName.Text, Describe = Describe.Text, Status=StatusRight.IsChecked.Value};
                db.Right.Add(RightStaff);
                db.SaveChanges();
               
                RightStaffs.ItemsSource = db.Right.ToList();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void RightStaffs_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var RightList = new BookStoreManagementData.BookStoreContext().Right.ToList();
            var RightStaffInfor= RightList.ElementAtOrDefault(RightStaffs.SelectedIndex);
            RightName.Text = RightStaffInfor.RightName;
            Describe.Text = RightStaffInfor.Describe;
            if (RightStaffInfor.Status)
            {
                StatusRight.IsChecked = true;
            }
            else
            {
                StatusRight.IsChecked = false;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var db = new BookStoreManagementData.BookStoreContext();
            var RightInfor = (db.Right.ToList()).ElementAtOrDefault(RightStaffs.SelectedIndex);
            RightInfor.RightName = RightName.Text;
            RightInfor.Describe = Describe.Text;
            RightInfor.Status= StatusRight.IsChecked.Value;
           
            db.SaveChanges();
            RightStaffs.ItemsSource = db.Right.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var db = new BookStoreManagementData.BookStoreContext();
            
            //var RightStaffInfor = (db.RightStaff.ToList()).ElementAtOrDefault();
            //RightStaffInfor.RightStaffName = RightStaffName.Text;
            //RightStaffInfor.Describe = Describe.Text;
            //db.SaveChanges();
            //RightStaffs.ItemsSource = db.RightStaff.ToList();
        }
    }
}
