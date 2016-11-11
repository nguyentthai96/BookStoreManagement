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
    public sealed partial class BookType : Page
    {
        public BookType()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                //foreach (BookStoreManagementData.Models.CustomModels.BookType item in db.BookType.ToList())
                //{
                //    db.Remove<BookStoreManagementData.Models.CustomModels.BookType>(item);
                    
                //}
                //db.SaveChanges();
                BookTypes.ItemsSource = db.BookType.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BookStoreManagementData.BookStoreContext())
            {
                BookStoreManagementData.Models.CustomModels.BookType bookType = new BookStoreManagementData.Models.CustomModels.BookType { BookTypeName = BookTypeName.Text, Describe = Describe.Text };
                db.BookType.Add(bookType);
                db.SaveChanges();

                List<BookStoreManagementData.Models.CustomModels.BookType> ls = db.BookType.ToList();
                BookStoreManagementData.Models.CustomModels.BookType v = new BookStoreManagementData.Models.CustomModels.BookType();
                v = ls.Last();
                //BookTypes.Items.Add(v);
                //NTT-TODO Tai sao khong the them mot phan tu
                BookTypes.ItemsSource = db.BookType.ToList();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void BookTypes_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var bookTypeList = new BookStoreManagementData.BookStoreContext().BookType.ToList();
            var bookTypeInfor= bookTypeList.ElementAtOrDefault(BookTypes.SelectedIndex);
            BookTypeName.Text = bookTypeInfor.BookTypeName;
            Describe.Text = bookTypeInfor.Describe;
        }
    }
}
