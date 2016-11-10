using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models
{
    public class Provider
    {
        public Provider()
        {
            Receipts = new HashSet<Receipt>();
            Books = new HashSet<Book>();
        }
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Describe { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
