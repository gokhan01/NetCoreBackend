using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.BLL.Abstract
{
    public interface IProductService
    {
        Product GetById(int productId);
        List<Product> GetList();
        List<Product> GetListByCategory(int categoryId);
        Product Add(Product product);
        Product Delete(Product product);
        Product Update(Product product);
    }
}
