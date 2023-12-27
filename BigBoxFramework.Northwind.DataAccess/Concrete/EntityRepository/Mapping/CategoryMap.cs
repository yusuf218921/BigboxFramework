using BigBoxFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.DataAccess.Concrete.EntityRepository.Mapping
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.CategoryID);

            Property(x => x.CategoryID).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
            
        }
    }
}
