using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.DataHandler.Reader.Clients.SAP.RFC
{
    public class RfcParam
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public RfcParam()
        {
            CoulmnNames = new List<string>();
            Param = new Dictionary<string, object>();
        }
        /// <summary>
        /// RFC方法名称
        /// </summary>
        public string RfcName { get; set; }
        /// <summary>
        /// RFC表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 数据表各列的列名
        /// </summary>
        public List<string> CoulmnNames { get; set; }
        /// <summary>
        /// RFC执行参数
        /// </summary>
        public Dictionary<string, object> Param { get; set; }
    }
}
