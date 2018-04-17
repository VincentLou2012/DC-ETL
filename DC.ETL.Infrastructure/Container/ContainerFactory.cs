using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.Container
{
    /// <summary>
    /// 容器工厂
    /// </summary>
    public class ContainerFactory 
    {
        //类型地址
        private readonly string _resolverPath;
        //类型类名
        private readonly string _resolverType;

        /// <summary>
        /// 由路径名称字符串构造工厂
        /// </summary>
        /// <param name="resolverTypeName">参数字符串</param>
        public ContainerFactory(string TypeStr)
        {
            string[] Params = TypeStr.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            _resolverPath = Params.First();
            _resolverType = Params.Last();
        }

        /// <summary>
        /// 由配置文件设定构造工厂
        /// </summary>
        public ContainerFactory()
            : this(ConfigurationManager.AppSettings["ContainerType"])
        {

        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns>容器实例</returns>
        public IContainer CreateInstance()
        {
            try
            {
                IContainer Resolver = (IContainer)Assembly.Load(_resolverPath).CreateInstance(_resolverType);
                return Resolver;
            }
            catch (Exception ex)
            {
                //TODO：错误日志
                return null;
            }
        }

    }
}
