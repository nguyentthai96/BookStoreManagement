using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementData.Models.CustomModels
{
   public class Account
    {
        public Account()
        {
            StaffRights = new HashSet<StaffRight>();
        }
        public string AccountID { get; set; }
        public string Password{ get; set; }
        public DateTime DayofCreate { get; set; }
        public string Describe { get; set; }
        public bool StatusAccount { get; set; }

        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual ICollection<StaffRight> StaffRights { get; set; }
    }
}
