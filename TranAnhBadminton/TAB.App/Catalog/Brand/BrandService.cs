using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.EF;
using TAB.Data.Entities;
using TAB.Ultilities.Exceptions;
using TAB.ViewModels.Catalog.Brand;
using TAB.ViewModels.Catalog.Products;

namespace TAB.App.Catalog.Brand
{
    public class BrandService : InterfaceBrandService
    {
        private readonly TABDbContext _context;
        public BrandService(TABDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(BrandCreateRequest request)
        {
            var brand = new Data.Entities.Brand();
            {
                //brand.BrandId = request.BrandId;
                brand.BrandName = request.BrandName;
                brand.Address = request.Address;
                brand.NumberPhone = request.NumberPhone;
                brand.Status = request.Status;
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand.BrandId;
        }

        public async Task<int> Delete(int brandId)
        {
            var brand = await _context.Brands.FindAsync(brandId);
            if (brand == null)
                throw new TABException($"Cannot find a brand: {brandId}");
            _context.Brands.Remove(brand);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BrandViewModel>> GetAll()
        {
            var query = from p in _context.Brands
                        select new { p };

            var data = await query
                .Select(x => new BrandViewModel()
                {
                    BrandId = x.p.BrandId,
                    BrandName = x.p.BrandName,
                    Address = x.p.Address,
                    NumberPhone = x.p.NumberPhone,
                    Status = x.p.Status,
                }).ToListAsync();

            return data;
        }

        public async Task<BrandViewModel> GetById(int brandId)
        {
            var brand = await _context.Brands.FindAsync(brandId);

            var brandViewModel = new BrandViewModel()
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                Address = brand.Address,
                NumberPhone = brand.NumberPhone,
                Status = brand.Status,
            };
            return brandViewModel;
        }

        public async Task<int> Update(BrandUpdateRequest request)
        {
            var brand = await _context.Brands.FindAsync(request.BrandId);
            if (brand == null)
                throw new TABException($"Cannot find a brand with id: {request.BrandId}");
            brand.BrandName = request.BrandName;
            brand.Address = request.Address;
            brand.NumberPhone = request.NumberPhone;
            brand.Status = request.Status;
            return await _context.SaveChangesAsync();
        }
    }
}
