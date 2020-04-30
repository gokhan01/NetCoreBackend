using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.Moq;
using Moq;
using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Concrete;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework;
using NetCoreBackend.Entities.Concrete;
using Xunit;

namespace NetCoreBackend.UnitTests.BLL
{
    public class ProductManagerTests
    {
        [Theory]
        [InlineData(1)]
        public void GetById_ValidParameter_Success(int productId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IProductDal>().Setup(productDal => productDal.Get(x => x.ProductId == productId))
                    .Returns(new Product { ProductName = "Test" });

                var productService = mock.Create<ProductManager>();

                var product = productService.GetById(1);

                Assert.Equal("Test", product.Data.ProductName);
            }
        }
    }
}
