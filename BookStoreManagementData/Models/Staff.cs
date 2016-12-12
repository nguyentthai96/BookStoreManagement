using BookStoreManagementData.Models.CustomModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookStoreManagementData.Models
{
    public class Staff
    {
        public Staff()
        {
            OrderDetails = new HashSet<CustomModels.OrderDetail>();

        }
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] ImageStaff { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public string Describe { get; set; }

        public string AccountID { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<CustomModels.OrderDetail> OrderDetails { get; set; }
    }
}
