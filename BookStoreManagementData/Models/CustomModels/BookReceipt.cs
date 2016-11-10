using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models.CustomModels
{
    public class BookReceipt
    {
        [Key, Column(Order = 0)]
        public string BookID { get; set; }
        [Key, Column(Order = 1)]
        public int ReceiptID { get; set; }
        public long Quantity { get; set; }
        public string DescribeReceiptBookDetail { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Receipt Receipt { get; set; }

    }
}
