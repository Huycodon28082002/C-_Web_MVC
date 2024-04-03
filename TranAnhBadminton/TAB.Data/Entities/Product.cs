using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB.Data.Entities
{

    public class Product
    {
        public int ProductId { set; get; }
        public int CategoryIds { set; get; }
        public string ProductName { set; get; }
        public string ProductImage {  set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }

        public bool? IsFeatured { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }

        public List<BillDetail> BillDetails { get; set; }

        public List<PromotionDetail> PromotionDetails { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public Category Category { get; set; }

        internal static IEnumerable<object> FromSqlRaw(string v)
        {
            throw new NotImplementedException();
        }
    }
}