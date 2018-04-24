using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    /// <summary>
    /// 操作类型<see cref="OPRecord"/>
    /// </summary>
    public enum EOptype
    {
        Add = 1,
        Update = 2,
        Delete = 3,
    }

    public enum EIsEnabled
    {
        True = 1,
        False = 0,
    }
}
