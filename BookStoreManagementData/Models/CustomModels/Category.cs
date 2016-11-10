using System.Collections.Generic;

namespace BookStoreManagementData.Models.CustomModels
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Describe { get; set; }
        public string StatusCategory { get; set; }

        //NTT-Delete
        public virtual ICollection<Book> Books { get; set; }
    }
}