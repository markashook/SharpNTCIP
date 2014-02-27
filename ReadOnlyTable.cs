using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP
{
    public abstract class ReadOnlyTable<K,V> : Table<K,V>
    {
        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
    }
}
