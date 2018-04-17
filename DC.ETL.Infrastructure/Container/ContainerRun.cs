using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DC.ETL.Infrastructure.Container
{
    /// <summary>
    /// 应用程序启动加载容器
    /// </summary>
    public class ContainerRun : IHttpModule
    {
        public ContainerRun() { }
        /// <summary>  
        /// 初始化事件。  
        /// </summary>  
        /// <param name="application">HttpApplication 对象。</param>  
        public void Init(HttpApplication application)
        {
            application.BeginRequest += BeginRequest;
            application.EndRequest += EndRequest;
        }

        /// <summary>  
        /// 销毁
        /// </summary>  
        public void Dispose()
        {
            Container.Reset();
        }

        /// <summary>  
        /// 接收请求事件。  
        /// </summary>  
        /// <param name="sender">引发事件的对象。</param>  
        /// <param name="e">事件对象。</param>  
        protected void BeginRequest(object sender, EventArgs e)
        {
            IContainer container = Container.Resolver;
        }

        /// <summary>  
        /// 请求结束事件。  
        /// </summary>  
        /// <param name="sender">引发事件的对象。</param>  
        /// <param name="e">事件对象。</param>  
        protected void EndRequest(object sender, EventArgs e)
        {
        }
    }
}
