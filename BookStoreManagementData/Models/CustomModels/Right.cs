using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models.CustomModels
{
    public class Right
    {
        public Right()
        {
            StaffRights = new HashSet<StaffRight>();
        }
        public int RightID { get; set; }
        public string RightName { get; set; }
        public string Describe { get; set; }
        public bool Status { get; set; }

        //NTT-Delete
        public virtual ICollection<StaffRight> StaffRights { get; set; }
    }
}
