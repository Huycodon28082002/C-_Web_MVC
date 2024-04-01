using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAB.ViewModels.Catalog.Bill
{
    public class BillCreateRequest
    {

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
