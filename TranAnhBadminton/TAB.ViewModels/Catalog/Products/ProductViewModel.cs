using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int ProductId { set; get; }
        public int CategoryIds { set; get; }
        public string ProductName { set; get; }
        public string ProductImage { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
    }
}
