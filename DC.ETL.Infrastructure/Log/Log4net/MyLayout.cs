﻿using log4net.Layout;
using log4net.Layout.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DC.ETL.Infrastructure.Log4net.Log
{
    /// <summary>
    /// log4net配置应用 输出实体使用 目前配置了输出到数据库方式
    /// </summary>
    public class PropLayout : PatternLayout
    {
        public PropLayout()
        {
            this.AddConverter("property", typeof(LogInfoPatternConverter));
        }
    }

    class LogInfoPatternConverter : PatternLayoutConverter
    {

        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                // Write the value for the specified key  
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                // Write all the key value pairs  
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }
        /// <summary>  
        /// 通过反射获取传入的日志对象的某个属性的值  
        /// </summary>  
        /// <param name="property"></param>  
        /// <returns></returns>  

        private object LookupProperty(string property, log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (propertyInfo != null)
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            return propertyValue;
        }
    }  
}
