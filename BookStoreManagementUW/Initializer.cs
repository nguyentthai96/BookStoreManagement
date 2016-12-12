using BookStoreManagementData;
using BookStoreManagementData.Models;
using BookStoreManagementData.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace BookStoreManagementUW
{
    public static class Initializer
    {
        public static async void insertData()
        {
            var db = new BookStoreManagementData.BookStoreContext();
            Category category1 = new Category() { CategoryID = 1, CategoryName = "Ke1", Describe = "Kê", StatusCategory = "ke sap sap roi" };
            db.Category.Add(category1);

            BookType booktype1 = new BookType() { BookTypeID = 1, BookTypeName = "Giáo trình", Describe = "Loại giáo trình gì ấy" };
            db.BookType.Add(booktype1);

            Publisher pubsher1 = new Publisher() { PublisherID = 1, Adress = "Hồ Chí Minh", Describe = "Nhà xuất bản 1", Phone = "00000000", PublisherName = "Nhà xuất bản lớn" };
            db.Publisher.Add(pubsher1);

            db.SaveChanges();

            #region add book
            db.Book.Add(new Book()
            {
                BookID = "GT01",
                BookName = "Mạng máy tính nâng cao",
                AuthorBook = "Huỳnh Nguyên Chính",
                BookType = booktype1,
                Category = category1,
                Publisher = pubsher1,
                BookPrice = 25000,
                BookCount = 100,
                BookPage = 187,
                BookCoverImage = null,
                Describe = "Sách giáo trình mạng máy tính",
            }
            );
            Book book2 = new Book()
            {
                BookID = "GT02",
                BookName = "Lập trình web với ASP.NET",
                AuthorBook = "Nguyễn Minh Đạo",
                BookType = booktype1,
                Category = category1,
                Publisher = pubsher1,
                BookPrice = 25000,
                BookCount = 100,
                BookPage = 187,
                BookCoverImage = null,
                Describe = "Sách giáo trình lập trình web",
            };
            db.Book.Add(book2);
            Book book3 = new Book()
            {
                BookID = "GT03",
                BookName = "Phân tích thuyết kế hệ thống hướng đối tượng với UML",
                AuthorBook = "Dương kiều Hoa",
                BookType = booktype1,
                Category = category1,
                Publisher = pubsher1,
                BookPrice = 25000,
                BookCount = 100,
                BookPage = 187,
                BookCoverImage = null,
                Describe = "Sách giáo trình UML",
            };
            db.Book.Add(book3);
            Book book4 = new Book()
            {
                BookID = "GT004",
                BookName = "Hệ điều hành",
                AuthorBook = "Trần hạnh nhi",
                BookType = booktype1,
                Category = category1,
                Publisher = pubsher1,
                BookPrice = 25000,
                BookCount = 100,
                BookPage = 187,
                BookCoverImage = null,
                Describe = "Sách giáo trình hệ điều hành",
            };
            db.Book.Add(book4);
            Book book5 = new Book()
            {
                BookID = "GT05",
                BookName = "Lập trình Android",
                AuthorBook = "Trương Thị Ngọc Phượng",
                BookType = booktype1,
                Category = category1,
                Publisher = pubsher1,
                BookPrice = 25000,
                BookCount = 100,
                BookPage = 187,
                BookCoverImage = null,
                Describe = "Sách giáo trình lập trình Android",
            };
            db.Book.Add(book5);

            db.SaveChanges();
            #endregion

            #region create and right, none staffright
            Right right = new Right()
            {
                RightName = "Thu ngân bán sách",
                Describe = "Thực hiện công việc bán sách",
                Status = true
            };
            #endregion
            db.Right.Add(right);
            db.SaveChanges();

            #region create account, none staffright and none staff - staffID
            Account account = new Account()
            {
                DayofCreate = DateTime.Now.Date,
                Password = "ntt123",
                AccountID = "thungan1",
                StatusAccount = true,
            };
            #endregion
           var acountDB= db.Account.Add(account);
            db.SaveChanges();

            #region create staff
            StorageFile fileImageStaff = await StorageFile.GetFileFromPathAsync(Path.Combine(Package.Current.InstalledLocation.Path, @"Assets\Images\person.png"));
            Staff staff = new Staff()
            {
                StaffName = "Nhân Viên Tên",
                PhoneNumber = "0987654321",
                Address = "Việt Nam",
                Birthday = DateTime.Parse("1/18/1996"),
                Gender = true,
                ImageStaff = fileImageStaff.AsByteArray().Result,
                Status = true, 
                AccountID=account.AccountID
            };
            #endregion
            db.Staff.Add(staff);
            db.SaveChanges();

            #region create staffright
            StaffRight staffRigth = new StaffRight()
            {
                Account = account,
                DateGrant = DateTime.Today,
                Right = right,
                Status = true
            };
            #endregion
            db.StaffRight.Add(staffRigth);
            db.SaveChanges();
        }
    }
}
