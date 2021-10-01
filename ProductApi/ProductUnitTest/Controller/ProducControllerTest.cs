using Microsoft.Extensions.Logging;
using Moq;
using ProductApi.Controllers;
using ProductApi.Dtos;
using ProductApi.Models;
using ProductApi.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProductUnitTest
{
    public class ProducControllerTest
    {
        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();
        private readonly Mock<ILogger<ProductController>> _loggerMock = new Mock<ILogger<ProductController>>();

        private readonly ProductController sut;
        public ProducControllerTest()
        {
            sut = new ProductController(_productServiceMock.Object, _loggerMock.Object);
        }
        [Fact]
        public async Task Get_Product_By_ProductId_Async()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var productInfo = new ProductInfo()
            {
                ProductId=productId
            };
            _productServiceMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(productInfo);

            //Act
            var product = await sut.GetProduct(productId);

            //Assert
            Assert.Equal(product.Value.ProductId, productInfo.ProductId);
        }

        [Fact]
        public async Task Get_Product_By_ProductId_Async_When_Record_DoesNot_Exist()
        {
            //Arrange
            var productId = Guid.NewGuid();
            _productServiceMock.Setup(x => x.GetProduct(It.IsAny<Guid>())).ReturnsAsync(()=> null);

            //Act
            var product = await sut.GetProduct(productId);

            //Assert
            Assert.Null(product.Value);
        }

        [Fact]
        public async Task Add_Product_Async()
        {
            //Arrange
            var productId = Guid.NewGuid();

            var ProductDto = new ProductDto()
            {
                Quantity = 1,
                Price = 10,
                ProductDesc = "Keyboard"
            };

            var productInfo = new ProductInfo()
            {
                ProductId = productId,
                Quantity = 1,
                Price = 10,
                ProductDesc = "Keyboard"
            };
            _productServiceMock.Setup(x => x.AddProduct(ProductDto)).ReturnsAsync(productInfo);

            //Act
            var product = await sut.AddProduct(ProductDto);

            //Assert
            Assert.Equal(product.Value.Quantity,  productInfo.Quantity);
            Assert.Equal(product.Value.Price, productInfo.Price);
            Assert.Equal(product.Value.ProductDesc, productInfo.ProductDesc);
        }

        public async Task Add_Product_Async_When_Record_Is_Null()
        {
            //Arrange
            var productId = Guid.NewGuid();

            var productInfo = new ProductInfo()
            {
                ProductId = productId,
                Quantity = 1,
                Price = 10,
                ProductDesc = "Keyboard"
            };
            _productServiceMock.Setup(x => x.AddProduct(It.IsAny<ProductDto>())).ReturnsAsync(productInfo);

            //Act
            var product = await sut.AddProduct(null);

            //Assert
            Assert.IsType<ArgumentNullException>(await sut.AddProduct(null));
        }



        [Fact]
        public async Task Update_Product_Async()
        {
            //Arrange
            var productId = Guid.NewGuid();

            var ProductDto = new ProductDto()
            {
                Quantity = 1,
                Price = 10,
                ProductDesc = "Keyboard"
            };

            var productInfo = new ProductInfo()
            {
                ProductId = productId,
                Quantity = 1,
                Price = 10,
                ProductDesc = "Keyboard"
            };

            _productServiceMock.Setup(x => x.GetProduct(productId)).ReturnsAsync(productInfo);
            _productServiceMock.Setup(x => x.UpdateProduct(ProductDto, productInfo)).ReturnsAsync(productInfo);

            //Act
            var product = await sut.UpdateProduct(ProductDto, productInfo.ProductId);

            //Assert
            Assert.Equal(product.Value.Quantity, productInfo.Quantity);
            Assert.Equal(product.Value.Price, productInfo.Price);
            Assert.Equal(product.Value.ProductDesc, productInfo.ProductDesc);
        }
        
    }
}
