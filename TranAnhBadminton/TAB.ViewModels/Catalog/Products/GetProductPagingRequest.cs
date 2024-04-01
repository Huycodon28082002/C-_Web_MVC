using System;
using System.Collections.Generic;
using System.Text;
using TAB.ViewModels.Catalog.Common;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}