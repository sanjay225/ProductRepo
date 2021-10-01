using ProductApi.Dtos;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Service
{
    public interface IProductService
    {
        Task<ProductInfo> GetProduct(Guid product_id);
        Task<IEnumerable<ProductInfo>> GetAllProduct();
        Task<ProductInfo> AddProduct(ProductDto productDto);
        Task<ProductInfo> UpdateProduct(ProductDto productDto, ProductInfo productToUpdate);
    }
}
