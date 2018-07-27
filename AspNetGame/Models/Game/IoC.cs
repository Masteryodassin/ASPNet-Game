using AspNetGame.Controllers.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGame.Models.Game
{
    /*public static class IoC
    {
        private static ServiceContainer container;
        public static ServiceContainer Container
        {
            get { return container = container ?? new ServiceContainer(); }
        }
    }*/
    public enum RegistrationStrategy
    {
        IGNORE,
        REJECT,
        PERMIT
    }
    public static class IoC
    {
        private static IDictionary<Type, object> registeredTypes = new Dictionary<Type, object>();

        public static RegistrationStrategy Registration { get; set; } = RegistrationStrategy.REJECT;

        public static bool AutoResolve { get; set; } = true;

        public static void Register<T>(T toRegister) where T : new()
        {
            if (Registration == RegistrationStrategy.PERMIT ||
                !registeredTypes.ContainsKey(typeof(T)))
            {
                registeredTypes.Add(typeof(T), toRegister);
            }
            else if (Registration == RegistrationStrategy.REJECT)
            {
                throw new InvalidOperationException(typeof(T).FullName + " is already registered.");
            }
        }

        public static void Register<T>(T toRegister, Action<T> injectionHandler) where T : new()
        {
            Register(toRegister);
            injectionHandler.Invoke(Resolve<T>());
        }

        public interface IInjectable
        {
            void SelfInitialize();
        }

        /*public interface Builder<T> where T : new()
        { 
            T build();
        }*/

        /*public abstract class AbstractBuilder<T> : Builder<T> where T : new()
        {
            protected AbstractBuilder()
            {
                Obj = (T)Activator.CreateInstance(typeof(T));
            }

            protected T Obj { get; }

            public T build()
            {
                return Obj;
            }
        }*/

        /*public class InjectionConfigBuilder : AbstractBuilder<InjectionConfig>
        {
            
            public InjectionConfig build()
            {
                throw new NotImplementedException();
            }
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInstanciableType"></typeparam>
        /// <returns></returns>
        public static TInstanciable Resolve<TInstanciable>() 
            where TInstanciable : new()
        {
            // If the wanted type is not registered
            if (!registeredTypes.ContainsKey(typeof(TInstanciable)))
            {
                // If AutoResolve flag is set to false, we return default value for T
                
                if (!AutoResolve)
                    return default(TInstanciable);

                // else, container will try to instanciate the type automatically 
                // (type must declare empty constructor)
                TInstanciable obj = (TInstanciable)Activator.CreateInstance(typeof(TInstanciable));

                // If obj implements Injectable, we call its own dependencies resolution method
                if (obj is IInjectable)
                {
                    (obj as IInjectable).SelfInitialize();
                }
                return obj;
            }
            else
            {
                return (TInstanciable)registeredTypes[typeof(TInstanciable)];
            }
        }


    }
}