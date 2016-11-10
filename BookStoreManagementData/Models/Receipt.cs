using System;
using System.Collections.Generic;
using BookStoreManagementData.Models.CustomModels;

namespace BookStoreManagementData.Models
{
    public class Receipt
    {
        public Receipt()
        {
            Books = new HashSet<Book>();
            BookReceipts = new HashSet<BookReceipt>();
        }
        public int ReceiptID { get; set; }
        public DateTime DayCreateReceipt { get; set; }
        public double ReceiptValueSum { get; set; }
        public string Describe { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public int ProviderID { get; set; }
        public Provider Providers { get; set; }

        public ICollection<BookReceipt> BookReceipts { get; set; }    
    }
}
