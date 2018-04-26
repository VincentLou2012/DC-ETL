using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using SAP.Middleware.Connector;

namespace DC.ETL.Infrastructure.DataHandler.Reader.Clients.SAP.RFC
{
    public class RfcDestinationConfig : IDestinationConfiguration
    {
        #region 事件
        /// <summary>
        /// 配置变更事件
        /// </summary>
        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
        /// <summary>
        /// 默认接收器名称
        /// </summary>
        public string DefaultDesName = string.Empty;
        #endregion

        public IDictionary<string, object> ConnParams { get; set; }

        public RfcDestinationConfig(IDictionary<string, object> param)
        {
            ConnParams = param;
            DefaultDesName = (string)ConnParams["Con_InstanceName"];
        }
        #region 方法
        /// <summary>
        /// 配置变更事件触发时，暂时无用
        /// </summary>
        /// <param name="destinationName"></param>
        /// <param name="args"></param>
        public void OnConfigurationChanged(string destinationName, RfcConfigurationEventArgs args)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(destinationName, args);
            }
        }

        /// <summary>
        /// 获取SAP配置参数
        /// </summary>
        /// <param name="destinationName"></param>
        /// <returns></returns>
        public RfcConfigParameters GetParameters(string destinationName)
        {
            if (destinationName == DefaultDesName)
            {
                RfcConfigParameters parms = new RfcConfigParameters
                {
                    { RfcConfigParameters.AppServerHost, (string)ConnParams["Con_IPAddress"] },   //SAP主机IP
                    { RfcConfigParameters.SystemNumber, (string)ConnParams["Con_SysNum"] },  //SAP系统号
                    { RfcConfigParameters.User, (string)ConnParams["Con_UserName"] },  //用户名
                    { RfcConfigParameters.Password, (string)ConnParams["Con_Password"] },  //密码
                    { RfcConfigParameters.Client, (string)ConnParams["Con_ClientNum"] },  // Client
                    { RfcConfigParameters.Language, (string)ConnParams["Con_Language"] }  //登陆语言
                };
                return parms;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 变更事件方法，暂时无用
        /// </summary>
        /// <returns>true</returns>
        public bool ChangeEventsSupported()
        {
            return true;
        }
        #endregion
    }
}
