using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.Data.Entities
{
    public class PromotionDetail
    {
        public int PromotionId { get; set; }
        public int ProductId { get; set; }
        public bool ApplyForAll { set; get; }
        public decimal DiscountPercent { set; get; }
        public decimal DiscountAmount { set; get; }
        public Status Status { set; get; }

        public Product Product { set; get; }
        public Promotion Promotion { set; get; }
    }
}
