using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.Container
{
    public static class Container
    {
        private static IContainer _resolver;
        //容器对象
        public static IContainer Resolver {
            get
            {
                if (_resolver == null) { return Initialize(new ContainerFactory()); }
                return _resolver;
            }
            set
            {
                _resolver = value;
            }
        }
        /// <summary>
        /// 容器初始化
        /// </summary>
        /// <param name="factory"></param>
        public static IContainer Initialize(ContainerFactory factory)
        {
            Resolver = factory.CreateInstance();
            return Resolver;
        }
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public static void Register<T>(T instance)
        {
            Resolver.Register(instance);
        }
        /// <summary>
        /// 注入对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="existing"></param>
        public static void Inject<T>(T existing)
        {
            Resolver.Inject(existing);
        }
        /// <summary>
        /// 获取类型实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T Resolve<T>(Type type)
        {
            return Resolver.Resolve<T>(type);
        }
        /// <summary>
        /// 通过命名和类型获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Resolve<T>(Type type, string name)
        {
            return Resolver.Resolve<T>(type, name);
        }
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }
        /// <summary>
        /// 通过命名获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Resolve<T>(string name)
        {
            return Resolver.Resolve<T>(name);
        }
        /// <summary>
        /// 获取所有需求类型实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ResolveAll<T>()
        {
            return Resolver.ResolveAll<T>();
        }
        /// <summary>
        /// 销毁容器
        /// </summary>
        public static void Reset()
        {
            if (Resolver != null)
            {
                Resolver.Dispose();
            }
        }
    }
}
