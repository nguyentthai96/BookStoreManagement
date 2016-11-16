using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementUW
{
   public static class Initializer
    {
        public static void insertData()
        {
            var db = new BookStoreManagementData.BookStoreContext();
            db.Category.Add(new BookStoreManagementData.Models.CustomModels.Category() { CategoryID = 1, CategoryName = "Ke1", Describe = "Ke dep", StatusCategory = "ke sap sap roi" });
            db.BookType.Add(new BookStoreManagementData.Models.CustomModels.BookType() { BookTypeID=1, BookTypeName="cccccccc", Describe="loai cccccc"});
            db.SaveChanges();
        }
    }
}
