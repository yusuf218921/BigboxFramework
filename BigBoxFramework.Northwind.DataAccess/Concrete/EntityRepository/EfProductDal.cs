using BigBoxFramework.Core.DataAccess.EntityRepository;
using BigBoxFramework.Northwind.DataAccess.Abstract;
using BigBoxFramework.Northwind.Entities.ComplexTypes;
using BigBoxFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.DataAccess.Concrete.EntityRepository
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryID
                             select new ProductDetail
                             {
                                 ProductId = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };

                return result.ToList();
                             
            }
        }
    }
}
