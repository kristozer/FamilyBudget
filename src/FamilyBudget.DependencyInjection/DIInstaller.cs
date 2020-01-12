using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudget.DependencyInjection
{
    internal class DIInstaller
    {
        private bool initialized;

        private readonly IServiceCollection services;
        private readonly Dictionary<Type, List<Action<IServiceCollection>>> registerBehaviourActionDictionary;
        
        public DIInstaller(IServiceCollection services)
        {
            this.services = services;
            registerBehaviourActionDictionary = new Dictionary<Type, List<Action<IServiceCollection>>>();
        }
        
        public void Initialize()
        {
            if (initialized)
            {
                return;
            }

            foreach (var action in registerBehaviourActionDictionary.SelectMany(x => x.Value))
            {
                action(services);
            }

            initialized = true;
        }

        public void RegisterByDIAttribute(string assemblyPath, string assemblySearchPattern)
        {
            var assemblyList = AssemblyExtensions.GetAssemblyByPattern(assemblyPath, assemblySearchPattern);
            var injectInfoList = assemblyList
                .SelectMany(a => a.GetTypes())
                .Where(x => x.IsDefined(typeof(InjectAttribute), false))
                .SelectMany(GetInterfaces);

            foreach (var (service, implementation, lifetime) in injectInfoList)
            {
                RegisterBehaviour(service, container => container.Add(new ServiceDescriptor(service, implementation, lifetime)));
            }
        }

        private static (Type Service, Type Implementation, ServiceLifetime Lifetime)[] GetInterfaces(Type type)
        {
            var result = Attribute.GetCustomAttributes(type, typeof(InjectAttribute), false)
                .Cast<InjectAttribute>()
                .Select(x => (Service: x.AbstractType, Implementation: type, Lifetime: GetLifetime(x)))
                .ToArray();

            //Если атрибут один и без явного указания типа абстракции, то ищем его интерфейсы, и регистрируем все
            if (result.Length == 1 && result[0].Service == null)
            {
                result = result
                    .SelectMany(x => type.GetInterfaces()
                        .Where(i => i.Namespace.StartsWith("FamilyBudget"))
                        .Select(service => (Service: service, x.Implementation, x.Lifetime)))
                    .ToArray();
            }

            return result.Where(x => x.Service != null && x.Service.IsAssignableFrom(x.Implementation)).ToArray();
        }

        private static ServiceLifetime GetLifetime(InjectAttribute attr)
        {
            switch (attr.Lifetime)
            {
                case InjectionLifetime.Transient:
                    return ServiceLifetime.Transient;
                case InjectionLifetime.PerScope:
                    return ServiceLifetime.Scoped;
                case InjectionLifetime.Singleton:
                    return ServiceLifetime.Singleton;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RegisterBehaviour(Type serviceType, Action<IServiceCollection> registerAction)
        {
            UnregisterBehaviour(serviceType);
            if (registerBehaviourActionDictionary.ContainsKey(serviceType) == false)
            {
                registerBehaviourActionDictionary.Add(serviceType, new List<Action<IServiceCollection>>());
            }
            registerBehaviourActionDictionary[serviceType].Add(registerAction);
        }

        private void UnregisterBehaviour(Type serviceType)
        {
            if (registerBehaviourActionDictionary.ContainsKey(serviceType))
            {
                registerBehaviourActionDictionary.Remove(serviceType);
            }
        }
    }
}