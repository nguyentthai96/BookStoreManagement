using System;
using System.Collections.Generic;

namespace BookStoreManagementData.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails =new HashSet<CustomModels.OrderDetail>();
        }
        public int OrderID { get; set; }
        public DateTime OrderDay { get; set; }
        public double OrderValueSum { get; set; }
        public string Describe { get; set; }

        public string CustomerPhoneID { get; set; }
        public virtual  Customer Customer { get; set; }

        public virtual ICollection<CustomModels.OrderDetail> OrderDetails { get; set; }
    }
}
