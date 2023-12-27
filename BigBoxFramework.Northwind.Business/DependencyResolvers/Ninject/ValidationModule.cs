﻿using BigBoxFramework.Northwind.Business.ValidationRules.FluentValidation;
using BigBoxFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
