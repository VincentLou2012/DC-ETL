using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.DataHandler
{
    public interface IReader<TDContainer>
    {
        /// <summary>
        /// 获取器参数
        /// </summary>
        IDictionary<string, object> Params { get; set; }

        /// <summary>
        /// 获取目标数据
        /// </summary>
        /// <returns></returns>
        TDContainer GetData(IDictionary<string, object> QueryParams);

        /// <summary>
        /// 验证连接
        /// </summary>
        /// <returns></returns>
        bool VerifyConn();
    }
}
