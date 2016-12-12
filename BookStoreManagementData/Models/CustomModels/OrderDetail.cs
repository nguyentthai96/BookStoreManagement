using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models.CustomModels
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public string BookID { get; set; }
        public int Quantity { get; set; }
        public double Money { get; set; }
        public string DescribeOrderBookDetail { get; set; }
        [ForeignKey("Staff")]
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
