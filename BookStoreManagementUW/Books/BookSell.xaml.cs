using BookStoreManagementData;
using BookStoreManagementData.Models;
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
    public sealed partial class BookSell : Page
    {
        private BookStoreContext db;
        private List<Book> listBook;
        public BookSell()
        {
            this.InitializeComponent();
        }

        private void BookSell_Loaded(object sender, RoutedEventArgs e)
        {
            db = new BookStoreContext();
            BookList.ItemsSource=db.Book.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new BookStoreContext();
            BookList.ItemsSource = db.Book.ToList().FindAll(s=>s.BookName.ToLower().Contains(SearchBox.Text.ToLower()));
        }

        private void ItemBook_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
