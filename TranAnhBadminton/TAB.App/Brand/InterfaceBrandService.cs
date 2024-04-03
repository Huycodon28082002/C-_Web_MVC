
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.ViewModels.Brand;
using TAB.ViewModels.Bill;
using TAB.ViewModels.Common;

namespace TAB.App.Brand
{
    public interface InterfaceBrandService
    {
        Task<int> Create(BrandCreateRequest request);

        Task<int> Update(BrandUpdateRequest request);

        Task<int> Delete(int brandId);

        Task<List<BrandViewModel>> GetAll();

        Task<BrandViewModel> GetById(int brandId);
    }
}
