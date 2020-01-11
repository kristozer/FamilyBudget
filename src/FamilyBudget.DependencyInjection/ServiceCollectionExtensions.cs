using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudget.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterByDIAttribute(this IServiceCollection services, string assemblySearchPattern)
        {
            var assemblyPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).LocalPath;
            var installer = new DIInstaller(services);
            installer.RegisterByDIAttribute(assemblyPath, assemblySearchPattern);
            installer.Initialize();
        }
    }
}