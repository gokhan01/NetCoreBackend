﻿using NetCoreBackend.Core.Entities;

namespace NetCoreBackend.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //public byte[] Picture { get; set; }
    }
}
