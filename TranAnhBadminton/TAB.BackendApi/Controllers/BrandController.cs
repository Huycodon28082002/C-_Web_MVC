using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAB.App.Catalog.Bill;
using TAB.App.Catalog.Brand;
using TAB.App.Catalog.Products;
using TAB.ViewModels.Catalog.Bill;
using TAB.ViewModels.Catalog.Brand;
using TAB.ViewModels.Catalog.Products;

namespace TAB.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly InterfaceBrandService _brandService;

        public BrandController(InterfaceBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BrandCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var brandId = await _brandService.Create(request);
            if (brandId == 0)
                return BadRequest("Cannot create brand");

            var bill = await _brandService.GetById(brandId);
            return CreatedAtAction(nameof(GetById), new { id = brandId }, brandId);
        }
        [HttpGet("{branndId}")]
        public async Task<IActionResult> GetById(int branndId)
        {
            var brand = await _brandService.GetById(branndId);
            if (brand == null)
                return BadRequest("Cannot find brand");
            return Ok(brand);
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var brand = await _brandService.GetAll();
            return Ok(brand);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] BrandUpdateRequest request)
        {
            var affectedResult = await _brandService.Update(request);
            if (affectedResult == 0)
                return BadRequest("Cannot update brand");

            return Ok();
        }
        [HttpDelete("brandId")]
        public async Task<IActionResult> Delete(int brandId)
        {
            var affectedResult = await _brandService.Delete(brandId);
            if (affectedResult == 0)
                return BadRequest("Cannot update brand");

            return Ok();
        }
    }
}
