using System;
using System.Collections.Generic;
using System.Text;
using TAB.ViewModels.Common;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}