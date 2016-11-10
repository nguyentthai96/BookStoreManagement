using System.Collections.Generic;

namespace BookStoreManagementData.Models
{
    public class Book
    {
        public Book()
        {
            BookReceipts = new HashSet<CustomModels.BookReceipt>();
        }
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorBook { get; set; }
        public byte[] BookCoverImage { get; set; }
        public string BookStatus { get; set; }
        public long BookPage { get; set; }
        public string Describe { get; set; }
        public double BookPrice { get; set; }
        public long BookCount  { get; set; }

        public int BookTypeID { get; set; }
        public virtual CustomModels.BookType BookType { get; set; }

        public int CategoryID { get; set; }
        public virtual CustomModels.Category Category { get; set; }

        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }

       
        public virtual ICollection<CustomModels.BookReceipt> BookReceipts { get; set; }
    }
}
