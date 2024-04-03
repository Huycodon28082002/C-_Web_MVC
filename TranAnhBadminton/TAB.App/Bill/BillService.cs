
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.App.Common;
using TAB.Data.EF;
using TAB.Data.Entities;
using TAB.ViewModels.Bill;

namespace TAB.App.Bill
{
    public class BillService : InterfaceBillService
    {
        private readonly TABDbContext _context;
        public BillService(TABDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(BillCreateRequest request)
        {
            // throw new NotImplementedException();
            var bill = new Data.Entities.Bill();
            {
                bill.UserId = request.UserId;
                bill.Name = request.Name;
                bill.DateCreated = request.DateCreated;
            };

            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill.BillId;
        }

        public async Task<List<BillViewModel>> GetBillAll()
        {
            var query = from p in _context.Bills
                        select new { p };

            var data = await query
                .Select(x => new BillViewModel()
                {
                    BillId = x.p.BillId,
                    UserId = x.p.UserId,
                    Name = x.p.Name,
                    DateCreated = x.p.DateCreated,
                }).ToListAsync();

            return data;
        }

        public async Task<BillViewModel> GetBillById(int BillId)
        {
            var bill = await _context.Bills.FindAsync(BillId);

            var billViewModel = new BillViewModel()
            {
                BillId = bill.BillId,
                UserId = bill.UserId,
                Name = bill.Name,
                DateCreated = bill.DateCreated,
            };
            return billViewModel;
        }

        Task<List<BillViewModel>> InterfaceBillService.GetBillByIdUser(Guid BillId)
        {
            throw new NotImplementedException();
        }
    }
}
