using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.Data.Entities
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }
        public int BrandId { set; get; }
        public Status Status { set; get; }

        public List<Product> Products { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public Brand Brand { set; get; }    
    }
}