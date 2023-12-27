using BigBoxFramework.Core.DataAccess;
using BigBoxFramework.Core.DataAccess.EntityRepository;
using BigBoxFramework.Northwind.Business.Abstract;
using BigBoxFramework.Northwind.Business.Concrete.Manager;
using BigBoxFramework.Northwind.DataAccess.Abstract;
using BigBoxFramework.Northwind.DataAccess.Concrete.EntityRepository;
using Ninject.Modules;
using System.Data.Entity;

namespace BigBoxFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind(typeof(IQueryableReposity<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
        }
    }
}
