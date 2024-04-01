using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.Data.Entities
{
    public class Promotion
    {
        public int PromotionId { set; get; }
        public string PromotionName { set; get; }
        public DateTime StartDay { set; get; }
        public DateTime EndDay { set; get; }
        public Status Status { set; get; }

        public List<PromotionDetail> PromotionDetails { set; get; }
    }
}