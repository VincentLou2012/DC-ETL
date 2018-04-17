using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain.Model
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public System.Guid SN
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            IAggregateRoot ar = obj as IAggregateRoot;
            if (ar == null)
                return false;
            return this.SN == ar.SN;
        }

        public override int GetHashCode()
        {
            return this.SN.GetHashCode();
        }
    }
}
