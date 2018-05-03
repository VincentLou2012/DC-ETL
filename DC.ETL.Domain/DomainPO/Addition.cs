using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DC.ETL.Domain
{
    public partial class Addition
    {     
        //TODO EF映射配置所属单元ID
        public Guid UnintID { get; set; }
        //加工名目
        public string Key { get; set; }
        //输入值
        public string Value { get; set; }
        //数据类型
        public string DataType { get; set; }
        //所属单元
        public virtual ExtractUnit Unit { get; set; }
    }
}
