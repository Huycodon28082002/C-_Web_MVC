using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.Data.Entities
{
    public class Bill
    {
        public int BillId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public List<BillDetail> BillDetails { get; set; }

        public User User { get; set; }
    }
}