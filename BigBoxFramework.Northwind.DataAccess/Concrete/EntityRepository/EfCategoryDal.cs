using BigBoxFramework.Core.DataAccess.EntityRepository;
using BigBoxFramework.Northwind.DataAccess.Abstract;
using BigBoxFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.DataAccess.Concrete.EntityRepository
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {

    }
}
