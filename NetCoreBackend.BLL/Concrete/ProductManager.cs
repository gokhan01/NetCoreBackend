using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Constants;
using NetCoreBackend.BLL.ValidationRules.FluentValidation;
using NetCoreBackend.Core.Aspects.Autofac.Caching;
using NetCoreBackend.Core.Aspects.Autofac.Transaction;
using NetCoreBackend.Core.Aspects.Validation;
using NetCoreBackend.Core.CrossCuttingConcerns.Validation;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.Entities.Concrete;
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

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryID == categoryId));
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.Updated);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)//Transaction Test
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.Added);
        }
    }
}
