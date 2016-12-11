using BookStoreManagementData;
using BookStoreManagementData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
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
        private static List<Book> listBookBuy;
        public BookSell()
        {
            listBookBuy = new List<Book>();
            this.InitializeComponent();
        }

        private void BookSell_Loaded(object sender, RoutedEventArgs e)
        {
            db = new BookStoreContext();
            BookList.ItemsSource=db.Book.ToList().FindAll(b=>b.BookCount>0);
        }

        private void ItemBook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var bookSelect = (Book)BookList.SelectedItem;
            Book bookBuy = new Book() {
                BookID = bookSelect.BookID,
                BookName = bookSelect.BookName,
                AuthorBook = bookSelect.AuthorBook,
                BookCount = bookSelect.BookCount,
                BookCoverImage = bookSelect.BookCoverImage,
                BookPage = bookSelect.BookPage,
                BookPrice = bookSelect.BookPrice,
                BookReceipts = bookSelect.BookReceipts,
                BookStatus = bookSelect.BookStatus,
                BookType = bookSelect.BookType,
                BookTypeID = bookSelect.BookTypeID,
                Category = bookSelect.Category,
                CategoryID = bookSelect.CategoryID,
                Describe = bookSelect.Describe,
                Publisher = bookSelect.Publisher,
                PublisherID = bookSelect.PublisherID
            };
            db.Book.ToList().SingleOrDefault(b => b.BookID == bookBuy.BookID).BookCount--;

            Book checkBookNew = listBookBuy.SingleOrDefault(b => b.BookID == bookBuy.BookID);
            if (checkBookNew!=null)
            {
                checkBookNew.BookCount++;
                BookBuyList.ItemsSource = new List<Book>();
                BookBuyList.ItemsSource = listBookBuy;
            }
            else
            {
                bookBuy.BookCount = 1;
                listBookBuy.Add(bookBuy);
                BookBuyList.ItemsSource = new List<Book>();
                BookBuyList.ItemsSource = listBookBuy;
            }

            BookList.ItemsSource = new List<Book>();
            BookList.ItemsSource = db.Book.ToList().FindAll(b => b.BookCount > 0);

            SumMoney.Text = listBookBuy.Sum(s => (s.BookCount * s.BookPrice)).ToString() + "  VNĐ";
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            BookList.ItemsSource = db.Book.ToList().FindAll(s => (s.BookName.ToLower().Contains(SearchBox.Text.ToLower())&&  s.BookCount > 0));
        }

        private async void BookCount_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9) & (e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9))
            {
                e.Handled = true;
            }
            if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Tab)
            {
                string bookIDChange = ((Book)((FrameworkElement)sender).DataContext).BookID;
                long countCurent = ((Book)((FrameworkElement)sender).DataContext).BookCount;
                long countNew = int.Parse((sender as TextBox).Text.Trim());
                if (countNew != countCurent)
                {
                    long bookCountExist = db.Book.ToList().SingleOrDefault(b => b.BookID == bookIDChange).BookCount;
                    if (bookCountExist < countNew - countCurent)
                    {
                        MessageDialog mesg = new MessageDialog("Số lượng sách không đủ");
                        await mesg.ShowAsync();
                        return;
                    }
                    db.Book.ToList().SingleOrDefault(b => b.BookID == bookIDChange).BookCount -= countNew - countCurent;
                    ((Book)((FrameworkElement)sender).DataContext).BookCount = countNew;
                    BookList.ItemsSource = new List<Book>();
                    BookList.ItemsSource = db.Book.ToList().FindAll(b => b.BookCount > 0);
                }
                SumMoney.Text = listBookBuy.Sum(s => (s.BookCount * s.BookPrice)).ToString() + "  VNĐ";
            }
        }

        private async void BookCount_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string bookIDChange = ((Book)((FrameworkElement)sender).DataContext).BookID;
                long countCurent = ((Book)((FrameworkElement)sender).DataContext).BookCount;
                long countNew = int.Parse((sender as TextBox).Text.Trim());
                if (countNew != countCurent)
                {
                    long bookCountExist = db.Book.ToList().SingleOrDefault(b => b.BookID == bookIDChange).BookCount;
                    if (bookCountExist < countNew - countCurent)
                    {
                        MessageDialog mesg = new MessageDialog("Số lượng sách không đủ");
                        await mesg.ShowAsync();
                        return;
                    }
                    db.Book.ToList().SingleOrDefault(b => b.BookID == bookIDChange).BookCount -= countNew - countCurent;
                    ((Book)((FrameworkElement)sender).DataContext).BookCount = countNew;
                    if (countNew == 0)
                    {
                        listBookBuy.Remove((Book)((FrameworkElement)sender).DataContext);
                        BookBuyList.ItemsSource = listBookBuy.ToList();
                    }
                    BookList.ItemsSource = new List<Book>();
                    BookList.ItemsSource = db.Book.ToList().FindAll(b => b.BookCount > 0);
                }
                SumMoney.Text = listBookBuy.Sum(s => (s.BookCount * s.BookPrice)).ToString() + "  VNĐ";
            }            catch (Exception ex )
            {
                if (ex.Message == "Object reference not set to an instance of an object.")
                {
                    MessageDialog mesg = new MessageDialog("Ham hố vừa phải hủy rồi còn đồi hủy nửa\n"+ex.Message);
                    await mesg.ShowAsync();
                }
            }
        }

        private void Remove_Taped(object sender, TappedRoutedEventArgs e)
        {
            long bookCount = ((Book)((FrameworkElement)sender).DataContext).BookCount;
            string bookIDChange = ((Book)((FrameworkElement)sender).DataContext).BookID;
            listBookBuy.Remove((Book)((FrameworkElement)sender).DataContext);
            BookBuyList.ItemsSource = listBookBuy.ToList();
            db.Book.ToList().SingleOrDefault(b => b.BookID == bookIDChange).BookCount+=bookCount;
            BookList.ItemsSource = new List<Book>();
            BookList.ItemsSource = db.Book.ToList().FindAll(b => b.BookCount > 0);
            SumMoney.Text = listBookBuy.Sum(s => (s.BookCount * s.BookPrice)).ToString() +"  VNĐ";
        }

        private void PrintOrder_Click(object sender, RoutedEventArgs e)
        {
          //  PrinterFormOld();

        }

        //private void PrinterFormOld()
        //{
        //    try
        //    {
        //        System.Windows.Forms.PrintDialog _PrintDialog = new System.Windows.Forms.PrintDialog();
        //        System.Drawing.Printing.PrintDocument _PrintDocument = new System.Drawing.Printing.PrintDocument();

        //        _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

        //        _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
        //        on a till you will not want to ask the user where to print but this is fine for the test envoironment.
        //        _PrintDocument.Print();
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        //private void _CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    Graphics graphic = e.Graphics;
        //    Font font = new Font("Courier New", 12);
        //    float FontHeight = font.GetHeight();
        //    int startX = 10;
        //    int startY = 10;
        //    int offset = 40;

        //    graphic.DrawString("COPPY TỚI RÙI TỚI LẠI", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
        //    string top = "Tên Sản Phẩm".PadRight(24) + "Thành Tiền";
        //    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
        //    offset = offset + (int)FontHeight; //make the spacing consistent
        //    graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
        //    offset = offset + (int)FontHeight + 5; //make the spacing consistent

        //    int index = 0;
        //    foreach (string item in lsbTenSanPham.Items)
        //    {
        //        graphic.DrawString(item, font, new SolidBrush(Color.Black), startX, startY + offset);
        //        graphic.DrawString(lsbThanhTien.Items[index++].ToString(), font, new SolidBrush(Color.Black), startX + 250, startY + offset);
        //        offset = offset + (int)FontHeight + 5; //make the spacing consistent              
        //    }

        //    offset = offset + 20; //make some room so that the total stands out.

        //    graphic.DrawString("TỔNG TIỀN TRẢ ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
        //    graphic.DrawString(_DoiSoSangDonViTienTe(nudTongTien.Value), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 250, startY + offset);

        //    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
        //    graphic.DrawString("TIỀN MẶT ", font, new SolidBrush(Color.Black), startX, startY + offset);
        //    graphic.DrawString(_DoiSoSangDonViTienTe(nudTienMat.Value), font, new SolidBrush(Color.Black), startX + 250, startY + offset);

        //    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
        //    graphic.DrawString("TIỀN TRẢ ", font, new SolidBrush(Color.Black), startX, startY + offset);
        //    graphic.DrawString(_DoiSoSangDonViTienTe(nudTienTra.Value), font, new SolidBrush(Color.Black), startX + 250, startY + offset);

        //    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
        //    graphic.DrawString(" CẢM ƠN BẠN ĐÃ GHÉ THĂM!,", font, new SolidBrush(Color.Black), startX, startY + offset);
        //    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
        //    graphic.DrawString("HI VỌNG BẠN SẼ GHÉ THĂM LẠI!", font, new SolidBrush(Color.Black), startX, startY + offset);
        //}


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            db = new BookStoreContext();
            BookList.ItemsSource = db.Book.ToList();
            listBookBuy = new List<Book>();
            BookBuyList.ItemsSource = listBookBuy;
            SumMoney.Text = "";
        }

        private void TelephoneNumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9) & (e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9))
            {
                e.Handled = true;
            }
        }
    }
}
