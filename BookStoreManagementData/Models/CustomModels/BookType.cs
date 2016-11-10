using System;
using System.Collections.Generic;

namespace BookStoreManagementData.Models.CustomModels
{
   public class BookType
    {
        public BookType()
        {
            Books = new HashSet<Book>();
        }

        public int BookTypeID { get; set; }
        public string BookTypeName { get; set; }
        public string Describe { get; set; }

        //NTT-Delete
        public virtual ICollection<Book> Books { get; set; }
    }
}