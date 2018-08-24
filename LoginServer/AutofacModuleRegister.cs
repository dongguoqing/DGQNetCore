using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;

namespace LoginServer
{
    public class AutofacModuleRegister:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetAssemblyByName("")).Where(a => a.Name.EndsWith("service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(GetAssemblyByName("")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }

        public static Assembly GetAssemblyByName(string assemblyName)
        {
            return Assembly.Load(assemblyName);
        }
    }
}
