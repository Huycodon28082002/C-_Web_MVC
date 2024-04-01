using TAB.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAB.App.Catalog.Products;

namespace TAB.BackendApi.Controllers
{
    // api/products
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly InterfaceProductService _productService;

        public ProductsController(InterfaceProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("search-products-by-name")]
        public async Task<IActionResult> SearchAllProduct(string productName)
        {
            var product = await _productService.SearchALLProduct(productName);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        // https://localhost:port/product
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        } 

        // https://localhost:port/product/1
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _productService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpGet("categoryId")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            var products = await _productService.GetAllByCategoryId(categoryId);
            return Ok(products);
        }

        // https://localhost:port/product/1
        [HttpPost]
        
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest("Cannot create product");

            var product = await _productService.GetById(productId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest("Cannot update product");

            return Ok();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest("Cannot update product");

            return Ok();
        }

    }

}

