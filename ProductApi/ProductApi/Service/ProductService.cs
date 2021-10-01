using ConfirmationSelfRegistrationServices.DataAccess;
using ProductApi.Dtos;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Service
{
    
    public class ProductService : IProductService
    {
        private readonly ContextProvider _contextProvider;

        public ProductService(ContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }
        public async Task<ProductInfo> AddProduct(ProductDto productDto)
        {
            var product = new ProductInfo()
            {
                ProductId = Guid.NewGuid(),
                ProductDesc = productDto.ProductDesc,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                CreatedDate = DateTime.UtcNow
            };
            _ = await _contextProvider.Products.AddAsync(product);
            _ = await _contextProvider.SaveChangesAsync();

            return product;
        }

        public async Task<IEnumerable<ProductInfo>> GetAllProduct()
        {
            var product =  _contextProvider.Products.ToList();
            return product;
        }

        public async Task<ProductInfo> GetProduct(Guid product_id)
        {
            var product = await _contextProvider.Products.FindAsync(product_id);
            return product;
        }

        public async Task<ProductInfo> UpdateProduct(ProductDto productDto, ProductInfo productToUpdate)
        {
            productToUpdate.Quantity = productDto.Quantity;
            productToUpdate.ProductDesc = productDto.ProductDesc;
            productToUpdate.Price = productDto.Price;
            _contextProvider.Products.Update(productToUpdate);
            _ = await _contextProvider.SaveChangesAsync();
            return productToUpdate;
        }
    }
}
