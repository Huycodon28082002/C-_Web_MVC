using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Enums;

namespace TAB.ViewModels.Brand
{
    public class BrandUpdateRequest
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Address { get; set; }
        public string NumberPhone { get; set; }
        public Status Status { get; set; }
    }
}
