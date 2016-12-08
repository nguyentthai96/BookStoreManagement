using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        private BookStoreManagementData.BookStoreContext db;

        public RightStaff()
        {
            this.InitializeComponent();
        }

        private void ComponemtDefault()
        {
            db = new BookStoreManagementData.BookStoreContext();
            RightStaffs.ItemsSource = db.Right.ToList();

            Edit.Visibility = Visibility.Collapsed;
            RightName.Text = String.Empty;
            Describe.Text = String.Empty;
            StatusRight.IsChecked = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ComponemtDefault();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            db = new BookStoreManagementData.BookStoreContext();
            var RightStaff = new BookStoreManagementData.Models.CustomModels.Right
                { RightName = RightName.Text, Describe = Describe.Text, Status = StatusRight.IsChecked.Value };

            db.Right.Add(RightStaff);
            db.SaveChanges();

            ComponemtDefault();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void RightStaffs_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var RightList = new BookStoreManagementData.BookStoreContext().Right.ToList();
            try
            {

                var RightStaffInfor = RightList.ElementAtOrDefault(RightStaffs.SelectedIndex);
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
            catch (Exception){}

            Edit.Visibility = Visibility.Visible;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            db = new BookStoreManagementData.BookStoreContext();
            var RightInfor = (db.Right.ToList()).ElementAtOrDefault(RightStaffs.SelectedIndex);
            RightInfor.RightName = RightName.Text;
            RightInfor.Describe = Describe.Text;
            RightInfor.Status = StatusRight.IsChecked.Value;

            db.SaveChanges();
            ComponemtDefault();
        }

        private void Delete_Click(int RightID)
        {
            db = new BookStoreManagementData.BookStoreContext();
            db.Remove(db.Right.ToList().Where(s => s.RightID == RightID).SingleOrDefault());
            db.SaveChanges();
            RightStaffs.ItemsSource = db.Right.ToList();
        }

        public static Rect GetElementRect(FrameworkElement element, Point point)
        {
            point.X -= 70;
            point.Y += 50;
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            buttonTransform.TransformPoint(point);
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
        private async void RightStafs_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var menu = new PopupMenu();

            menu.Commands.Add(new UICommand("Xóa", (command) =>
            {
                Delete_Click((((FrameworkElement)e.OriginalSource).DataContext
                    as BookStoreManagementData.Models.CustomModels.Right).RightID);
            }));

            await menu.ShowForSelectionAsync(GetElementRect((FrameworkElement)sender, e.GetPosition(sender as TextBlock)));
        }
    }
}