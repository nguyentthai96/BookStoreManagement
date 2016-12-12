using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreManagementData.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        [MinLength(0),MaxLength(12)]
        public string CustomerPhoneID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DayFirstPurchase { get; set; }
        public string Address { get; set; }
        public string Decribe { get; set; }
        public bool FriendlyCustomer { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
