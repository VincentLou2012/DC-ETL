using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public partial class UnitBehavior
    {
        //发生时间
        public DateTime Time { get; set; }
        //TODO EF映射配置单元序列
        public Guid UnitID { get; set; }
        //结果
        public string Result { get; set; }
        //影响行数
        public int EffectRows { get; set; }
        //备注
        public string Comment { get; set; }
        //所属单元
        public virtual ExtractUnit Unit { get; set; }
    }
}
