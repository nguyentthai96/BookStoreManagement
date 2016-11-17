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

namespace BookStoreManagementUW.Books
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Category : Page
    {
        public Category()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                Categorys.ItemsSource = db.Category.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                BookStoreManagementData.Models.CustomModels.Category Category = new BookStoreManagementData.Models.CustomModels.Category { CategoryName = CategoryName.Text, Describe = Describe.Text, StatusCategory=StatusCategory.Text};
                db.Category.Add(Category);
                db.SaveChanges();
               
                Categorys.ItemsSource = db.Category.ToList();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Categorys_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var CategoryList = new BookStoreManagementData.BookStoreContext().Category.ToList();
            var CategoryInfor= CategoryList.ElementAtOrDefault(Categorys.SelectedIndex);
            CategoryName.Text = CategoryInfor.CategoryName;
            Describe.Text = CategoryInfor.Describe;
            StatusCategory.Text = CategoryInfor.StatusCategory;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var db = new BookStoreManagementData.BookStoreContext();
            var CategoryInfor = (db.Category.ToList()).ElementAtOrDefault(Categorys.SelectedIndex);
            CategoryInfor.CategoryName = CategoryName.Text;
            CategoryInfor.Describe = Describe.Text;
            CategoryInfor.StatusCategory= StatusCategory.Text;
            db.SaveChanges();
            Categorys.ItemsSource = db.Category.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var db = new BookStoreManagementData.BookStoreContext();
            
            //var CategoryInfor = (db.Category.ToList()).ElementAtOrDefault();
            //CategoryInfor.CategoryName = CategoryName.Text;
            //CategoryInfor.Describe = Describe.Text;
            //db.SaveChanges();
            //Categorys.ItemsSource = db.Category.ToList();
        }
    }
}
