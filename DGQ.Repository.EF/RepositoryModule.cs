using Autofac;
using DGQ.Infrustructure.Contract;
using DGQ.Infrustructure.EF;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DGQ.Repository.EF
{
    public class RepositoryModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
