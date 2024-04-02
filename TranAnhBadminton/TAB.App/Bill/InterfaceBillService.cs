using eShopSolution.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.ViewModels.Catalog;
using TAB.ViewModels.Bill;

namespace TAB.App.Bill
{
    public interface InterfaceBillService
    {
        Task<int> Create(BillCreateRequest request);
        Task<BillViewModel> GetBillById(int BillId);
        Task<List<BillViewModel>> GetBillByIdUser(Guid BillId);
        Task<List<BillViewModel>> GetBillAll();

    }
}
