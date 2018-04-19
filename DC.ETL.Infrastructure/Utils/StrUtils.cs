using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.Utils
{
    /// <summary>
    /// string 工具类
    /// 2018-04-19 09:26:55
    /// </summary>
    public class StrUtils
    {
        /// <summary>
        /// 按顺序连接多个输入参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string ToString(params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object str in args)
            {
                sb.Append(" ");
                if (str != null) sb.Append(str);
                //else input += " NULL";
            }
            return sb.ToString();
        }
    }
}
