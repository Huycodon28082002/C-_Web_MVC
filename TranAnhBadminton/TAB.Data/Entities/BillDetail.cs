using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.Data.Entities
{
    public class BillDetail
    {
        
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }

        public Bill Bill { get; set; }
        public Product Product { get; set; }
    }
}