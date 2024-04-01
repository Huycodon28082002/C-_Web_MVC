using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using TAB.Data.Enums;

namespace TAB.ViewModels.Catalog.Brand
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public Status Status { get; set; }
        public List<Category> Categories { get; set; }
    }
}
