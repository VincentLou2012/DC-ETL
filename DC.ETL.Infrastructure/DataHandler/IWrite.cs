using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.DataHandler
{
    public interface IWrite<TDC>
    {
        /// <summary>
        /// 写入类型
        /// </summary>
        IWriter<TDC> writer { get; set; }
        /// <summary>
        /// 验证数据模式
        /// </summary>
        /// <returns></returns>
        bool VerifySchema();
        /// <summary>
        /// 解析参数
        /// </summary>
        /// <param name="TargetName">目标表名</param>
        /// <param name="Fields">字段集合</param>
        void ResolveParam(string TargetName, IList<string> Fields);
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="data">数据容器</param>
        void WriteData(TDC data);
    }
}
