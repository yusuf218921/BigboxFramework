using BigBoxFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Core.DataAccess
{
    public interface IQueryableReposity<T> where T: class, IEntity, new() 
    {
        IQueryable<T> Table { get; }
    }
}
