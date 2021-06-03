using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYPP.Service.Container
{
    public static class ServiceContainer
    {
        static readonly Dictionary<Type, Lazy<object>> services
            = new Dictionary<Type, Lazy<object>>();

        public static void Register<T>(Func<T> function)
            => services[typeof(T)] = new Lazy<object>(() => function());
        public static void Initiate<T>(Func<T> obj)
            => services[typeof(T)] = new Lazy<object>(() => obj());
        public static T Get<T>()
            => (T)Get(typeof(T));

        public static object Get(Type type)
        {
            {
                if (services.TryGetValue(type, out var service))
                    return service.Value;

                throw new KeyNotFoundException($"Service not found for type '{type}'");
            }
        }
    }
}
