﻿using NetCoreBackend.Core.DAL;
using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.DAL.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
