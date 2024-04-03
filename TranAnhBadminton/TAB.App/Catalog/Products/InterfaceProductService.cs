using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.ViewModels.Catalog.Products;
using TAB.ViewModels.Common;

namespace TAB.App.Catalog.Products
{
    public interface InterfaceProductService
    {
        // Manage
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productID);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        // Public
        Task<List<ProductViewModel>> GetAll();
        Task<List<ProductViewModel>> GetAllByCategoryId(int categoryId);
        Task<ProductViewModel> GetById(int productId);
        Task<List<ProductViewModel>> SearchALLProduct(string productName);
    }
}
