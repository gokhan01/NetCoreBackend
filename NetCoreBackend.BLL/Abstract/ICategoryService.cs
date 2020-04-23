using NetCoreBackend.Core.Utilities.Results;
using NetCoreBackend.Entities.Concrete;
using System.Collections.Generic;

namespace NetCoreBackend.BLL.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetList();
        IDataResult<Category> Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}
