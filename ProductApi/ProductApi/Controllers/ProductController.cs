using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApi.Dtos;
using ProductApi.Models;
using ProductApi.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{

    public class ProductController : Controller
    {
        public IProductService _productService { get; }
        public ILogger<ProductController> _logger { get; }

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<ProductInfo>> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                _logger.LogInformation("No record available with id: {id)}", id);
                return NotFound("No record available with id: "+id);
            }
            return product;
        }

        [HttpPost("product/add-product")]
        public async Task<ActionResult<ProductInfo>> AddProduct([FromBody]ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            var product = await _productService.AddProduct(productDto);
            _logger.LogInformation("New product added with id: {ProductId}", product.ProductId);
            return product;
        }

        [HttpPost("product/product-list")]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> GetAllProduct()
        {
            var product = await _productService.GetAllProduct();
            if (product == null)
            {
                return NotFound("No Records Found.");
            }
            return Ok(product);
        }

        [HttpPut("product/update-product")]
        public async Task<ActionResult<ProductInfo>> UpdateProduct([FromBody]ProductDto productDto, Guid product_id)
        {
            if (productDto == null)
                return NotFound("please enter valid product.");

            if (product_id == Guid.Empty)
                return NotFound("product id is required.");

            var product = await _productService.GetProduct(product_id);
            if (product == null)
            {
                _logger.LogInformation("No record available to update with id: {ProductId}", product_id);
                return NotFound("No record available to update with id: "+ product_id);
            }

            var updated_product = await _productService.UpdateProduct(productDto, product);
            _logger.LogInformation("product updated with id: {ProductId}", product_id);
            return updated_product;
        }
    }
}
