using BigBoxFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using BigBoxFramework.Northwind.Business.Abstract;
using BigBoxFramework.Northwind.Business.ValidationRules.FluentValidation;
using BigBoxFramework.Northwind.DataAccess.Abstract;
using BigBoxFramework.Northwind.Entities.Concrete;
using BigBoxFramework.Core.Aspects.PostSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBoxFramework.Core.DataAccess;
using BigBoxFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using BigBoxFramework.Core.Aspects.PostSharp.Logging;
using System.Data.Entity.Infrastructure.Interception;

namespace BigBoxFramework.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IQueryableReposity<Product> _queryable;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [LogAspect(typeof(DatabaseLogger))]
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager), 120)]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }
        [TransactipnScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //
            _productDal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Update(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
