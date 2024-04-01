using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TAB.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        // public int Id {  get; set; }
        // public string PhoneNumber {  get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public string? Avatar { get; set; }

        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }

        public List<Bill> Bills { get; set; }
    }

    public interface IEntityUser<T>
    {
    }
}