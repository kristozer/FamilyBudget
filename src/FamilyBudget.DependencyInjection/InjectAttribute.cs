using System;

namespace FamilyBudget.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class InjectAttribute : Attribute
    {
        protected InjectAttribute(InjectionLifetime lifetime, Type abstractType)
        {
            Lifetime = lifetime;
            AbstractType = abstractType;
        }

        public InjectionLifetime Lifetime { get; }

        public Type AbstractType { get; }
    }
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class InjectAsSingletonAttribute : InjectAttribute
    {
        public InjectAsSingletonAttribute(Type abstractType) : base(InjectionLifetime.Singleton, abstractType)
        {
        }
        
        /// <summary>
        /// Регистрируются все абстракции по цепочкам
        /// </summary>
        public InjectAsSingletonAttribute() : base(InjectionLifetime.Singleton, null)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class InjectAsTransientAttribute : InjectAttribute
    {
        public InjectAsTransientAttribute(Type abstractType) : base(InjectionLifetime.Transient, abstractType)
        {
        }
        
        /// <summary>
        /// Регистрируются все абстракции по цепочкам
        /// </summary>
        public InjectAsTransientAttribute() : base(InjectionLifetime.Transient, null)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class InjectPerScopeAttribute : InjectAttribute
    {
        public InjectPerScopeAttribute(Type abstractType) : base(InjectionLifetime.PerScope, abstractType)
        {
        }
        
        /// <summary>
        /// Регистрируются все абстракции по цепочкам
        /// </summary>
        public InjectPerScopeAttribute() : base(InjectionLifetime.PerScope, null)
        {
        }
    }
}