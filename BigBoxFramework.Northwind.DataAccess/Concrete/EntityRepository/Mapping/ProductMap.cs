using BigBoxFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.DataAccess.Concrete.EntityRepository.Mapping
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products",@"dbo");
            HasKey(x => x.ProductID);

            Property(x => x.ProductID).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
            Property(x => x.ProductName).HasColumnName("ProductName");
        }
    }
}
