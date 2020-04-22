using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        public Product Delete(Product product)
        {
            return _productDal.Delete(product);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryID == categoryId);
        }

        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}
