using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;

namespace TAB.Data.Entities
{
    public class Cart
    {
        public int CartId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}