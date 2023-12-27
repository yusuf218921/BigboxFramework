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
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
