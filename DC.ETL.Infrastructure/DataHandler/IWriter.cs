using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Infrastructure.DataHandler
{
    public interface IWriter<TDC>
    {
        void WriteData(TDC data, IDictionary<string,string> Params);
    }
}
