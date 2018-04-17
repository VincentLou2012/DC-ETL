using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace DC.ETL.Infrastructure.Container
{
    public class UnityResolver : DisposableResource, IContainer
    {
        //Unity注入容器
        private readonly IUnityContainer _container;

        /// <summary>
        /// 构造Unity容器,获取Unity配置
        /// </summary>
        public UnityResolver() : this(new UnityContainer())
        {
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            _container.LoadConfiguration(configuration);
        }

        /// <summary>
        /// 构造Unity容器
        /// </summary>
        /// <param name="container">容器对象</param>
        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// 注册默认实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="instance">对象实例</param>
        public void Register<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }
        /// <summary>
        /// 注册命名实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">实例名称</param>
        /// <param name="instance">对象实例</param>
        public void Register<T>(string name, T instance)
        {
            _container.RegisterInstance(name, instance);
        }

        /// <summary>
        /// 注入加载
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="existing">已存在的对象实例</param>
        [DebuggerStepThrough]
        public void Inject<T>(T existing)
        {
            _container.BuildUp(existing);
        }

        /// <summary>
        /// 从容器获取实例
        /// </summary>
        /// <typeparam name="T">需求类型</typeparam>
        /// <param name="type">目标类型</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(Type type)
        {
            return (T)_container.Resolve(type);
        }

        /// <summary>
        /// 从容器获取命名实例
        /// </summary>
        /// <typeparam name="T">需求类型</typeparam>
        /// <param name="type">目标类型</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(Type type, string name)
        {
            return (T)_container.Resolve(type, name);
        }
        /// <summary>
        /// 从容器获取默认实例
        /// </summary>
        /// <typeparam name="T">需求类型</typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 通过命名获取实例
        /// </summary>
        /// <typeparam name="T">需求类型</typeparam>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public T Resolve<T>(string name)
        {
            return _container.Resolve<T>(name);
        }

        /// <summary>
        /// 获取所有需求实例
        /// </summary>
        /// <typeparam name="T">需求类型</typeparam>
        /// <returns></returns>
        [DebuggerStepThrough]
        public IEnumerable<T> ResolveAll<T>()
        {
            //获取所有注册实例
            IEnumerable<T> namedInstances = _container.ResolveAll<T>();
            T unnamedInstance = default(T);
            try
            {
                //获取默认实例
                unnamedInstance = _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                //缺少默认实例
            }
            if (Equals(unnamedInstance, default(T)))
            {
                return namedInstances;
            }
            return new ReadOnlyCollection<T>(new List<T>(namedInstances) { unnamedInstance });
        }

        /// <summary>
        /// 选择销毁对象
        /// </summary>
        /// <param name="disposing">是否销毁容器对象</param>
        [DebuggerStepThrough]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _container.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
