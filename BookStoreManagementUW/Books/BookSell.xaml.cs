using BookStoreManagementData;
using BookStoreManagementData.Models;
using BookStoreManagementData.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private Order order;
        private Staff staff;
        private Customer customer;
        public BookSell()
        {
            listBookBuy = new List<Book>();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.staff = (Staff)e.Parameter;
            
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

        private async void PrintOrder_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneNumberCustomer.Text == "" || CustomerName.Text == "")
            {
                MessageDialog mes = new MessageDialog("Bạn nhập thiếu tên khách hàng hoặc số điện thoại");
                await mes.ShowAsync();
                return;
            }

            OrderData();

            //db.Order.Add(order);
            ListBuyStackPanel.Visibility = Visibility.Collapsed;
            ReceiptStackPanel.Visibility = Visibility.Visible;
            ViewData();
        }

        private void ViewData()
        {
            OrderID.Text=order.OrderID.ToString();
            OrderDaySell.Text = order.OrderDay.ToString("dd / MM / yyyy");
            StaffOrder.Text = staff.StaffName;
            CustomerNameOrderView.Text = customer.CustomerName;

            OrderBookListView.ItemsSource = order.OrderDetails;
            
            QuantityBookSum.Text = order.OrderDetails.ToList().Sum(b=>b.Quantity).ToString();
            OrderValueSum.Text = order.OrderValueSum.ToString() + "  VNĐ";
        }

        private void OrderData()
        {
            #region Check customer existed, inilizer customer and save custommer new
            using (var dbCustomer = new BookStoreContext())
            {
                customer= dbCustomer.Customer.ToList().Find(c => c.CustomerPhoneID == PhoneNumberCustomer.Text.Trim());
                if (customer==null)
                {
                    customer = new Customer();
                    customer.CustomerPhoneID = PhoneNumberCustomer.Text;
                    customer.CustomerName = CustomerName.Text;
                    dbCustomer.Customer.Add(customer);
                    dbCustomer.SaveChanges();
                }
            }
            #endregion

            #region create order new, none sumMoney
            order = new Order()
            {
                OrderDay = DateTime.Now.Date,
                Customer = customer,
                CustomerPhoneID = customer.CustomerPhoneID,
            };
            #endregion

            #region create list order and summonney all book buy
            List<OrderDetail> orderList = new List<OrderDetail>();
            double sumMonneyOrder = 0;
            foreach (Book bookItem in listBookBuy)
            {
                OrderDetail orderDetail = CreateOrderDetail(order, bookItem);
                orderList.Add(orderDetail);
                sumMonneyOrder += orderDetail.Money;
            }
            #endregion
            order.OrderValueSum = sumMonneyOrder;
            order.OrderDetails = orderList;
        }

        private OrderDetail CreateOrderDetail(Order order, Book book)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.Book = book;
            orderDetail.BookID = book.BookID;
            orderDetail.OrderID = order.OrderID;
            orderDetail.StaffID = staff.StaffID;
            orderDetail.Quantity = (int)book.BookCount;
            orderDetail.Money = book.BookCount * book.BookPrice;
            orderDetail.Staff = staff;
            // using (var dbOrder = new BookStoreContext())
            //{
            //   dbOrder.OrderDetail.Add(orderDetail);
            //   dbOrder.SaveChanges();
            //}
            return orderDetail;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ResetView();
        }

        private void TelephoneNumber_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9) & (e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9))
            {
                e.Handled = true;
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            Order orderSave = new Order();
            orderSave.CustomerPhoneID = order.CustomerPhoneID;
            orderSave.OrderDay = order.OrderDay;
            orderSave.OrderValueSum = order.OrderValueSum;
            var orderSaveDB=db.Order.Add(orderSave);
            db.SaveChanges();

            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                OrderDetail orderDetailSave = new OrderDetail();
                orderDetailSave.BookID = orderDetail.BookID;
                orderDetailSave.Money = orderDetail.Money;
                orderDetailSave.OrderID = orderSaveDB.Entity.OrderID;
                orderDetailSave.Quantity = orderDetail.Quantity;
                orderDetailSave.StaffID = orderDetail.StaffID;
                using (var dbSaveOrderDetail = new BookStoreContext())
                {
                    dbSaveOrderDetail.OrderDetail.Add(orderDetailSave);
                    dbSaveOrderDetail.SaveChanges();
                }
            }

            ResetView();
        }

        private void CancelFinish_Click(object sender, RoutedEventArgs e)
        {
            ResetView();
        }

        private void ResetView()
        {
            db = new BookStoreContext();
            BookList.ItemsSource = db.Book.ToList();
            listBookBuy = new List<Book>();
            BookBuyList.ItemsSource = listBookBuy;
            SumMoney.Text = "";
            CustomerName.Text = "";
            PhoneNumberCustomer.Text = "";
            ListBuyStackPanel.Visibility = Visibility.Visible;
            ReceiptStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
