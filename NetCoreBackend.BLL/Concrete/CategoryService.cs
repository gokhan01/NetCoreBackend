using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Constants;
using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.Entities.Concrete;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Concrete
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList());
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
