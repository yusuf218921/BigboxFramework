﻿using BigBoxFramework.Core.DataAccess;
using BigBoxFramework.Northwind.Entities.ComplexTypes;
using BigBoxFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
