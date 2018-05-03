using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.ETL.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public System.Guid ID
        {
            get;
            set;
        }

        public int IsEnabled
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
            return this.ID == ar.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public virtual void Serialize()
        {

        }
    }
}
