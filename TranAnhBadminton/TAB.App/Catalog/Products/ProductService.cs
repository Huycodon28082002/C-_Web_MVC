using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.App.Common;
using TAB.Data.EF;
using TAB.Data.Entities;
using TAB.Ultilities.Exceptions;
using TAB.ViewModels.Catalog.Products;
using TAB.ViewModels.Common;

namespace TAB.App.Catalog.Products
{
    public class ProductService : InterfaceProductService
    {
        // Manage
        private readonly TABDbContext _context;
        private readonly InterfaceStorageService _storageService;
        public ProductService(TABDbContext context, InterfaceStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            // throw new NotImplementedException();
            var product = new Product()
            {
                ProductName = request.ProductName,
                // ProductImage = request.ProductImage,
                Description = request.Description,
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                CategoryIds = request.CategoryIds,
            };

            //Save image
            if (request.ThumbnailImage != null)
                product.ProductImage = await this.SaveFile(request.ThumbnailImage);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }

        private readonly ProductUpdateRequest request;
        public async Task<int> Delete(int productId)
        {
            
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new TABException($"Cannot find a product: {productId}");

            // Delete image
            if (!string.IsNullOrEmpty(product.ProductImage))
            {
                await this.DeleteFile(product.ProductImage);
                product.ProductImage = null; // Gán giá trị null để xác định rằng ảnh đã bị xóa
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            // 1. Select join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId
                        select new { p, pic };

            // 3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    DateCreated = x.p.DateCreated,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    CategoryIds = x.p.CategoryIds,
                }).ToListAsync();
            // 4.Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };

            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null)
                throw new TABException($"Cannot find a product with id: {request.ProductId}");
            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Price = request.Price;
            product.OriginalPrice = request.OriginalPrice;
            product.Stock = request.Stock;
            product.ViewCount = request.ViewCount;
            if (request.ThumbnailImage != null)
                product.ProductImage = await this.SaveFile(request.ThumbnailImage);

            return await _context.SaveChangesAsync();
        }

        public Task<bool> UpdateOriginalPrice(int productId, decimal newOriginalPrice)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new TABException($"Cannot find a product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new TABException($"Cannot find a product with id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;

        }

        private async Task DeleteFile(string fileName)
        {
            await _storageService.DeleteFileAsync(fileName);
        }


        public async Task<ProductViewModel> GetByCategoryId(int CategoryIds)
        {
            var product = _context.Products.Find(CategoryIds);

            var productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                CategoryIds = product.CategoryIds,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.DateCreated,
            };
            return productViewModel;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productViewModel = new ProductViewModel()
            {
                ProductId = product.ProductId,
                CategoryIds = product.CategoryIds,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.DateCreated,
            };
            return productViewModel;
        }


        // Public

        public ProductService(TABDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        select new { p };

            var data = await query
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    ProductImage = x.p.ProductImage,
                    DateCreated = x.p.DateCreated,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    CategoryIds = x.p.CategoryIds,
                }).ToListAsync();

            return data;
        }

        public async Task<List<ProductViewModel>> GetAllByCategoryId(int categoryId)
        {
            //1. Select join
            var query = from p in _context.Products
                        where p.CategoryIds == categoryId
                        select new { p };

            var data = await query
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    DateCreated = x.p.DateCreated,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    CategoryIds = x.p.CategoryIds,
                }).ToListAsync();

            return data;

        }

        public async Task<List<ProductViewModel>> SearchALLProduct(string productName)
        {
            //1. Select join
            var query = from p in _context.Products
                        where p.ProductName.Contains(productName)
                        select new { p };

            var data = await query
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.ProductId,
                    ProductName = x.p.ProductName,
                    DateCreated = x.p.DateCreated,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    CategoryIds = x.p.CategoryIds,
                }).ToListAsync();

            return data;
        }
    }
}
