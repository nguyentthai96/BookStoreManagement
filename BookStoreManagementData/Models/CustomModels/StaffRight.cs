using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models.CustomModels
{
    public class StaffRight
    {
        [Key, Column(Order = 0)]
        public int RightID { get; set; }
        [Key, Column(Order = 1)]
        public string AccountID { get; set; }
        public DateTime DateGrant { get; set; }
        public string Describe { get; set; }
        public bool Status { get; set; }

        public virtual Account Account { get; set; }
        public virtual Right  Right { get; set; }
    }
}
