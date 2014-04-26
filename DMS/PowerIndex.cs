using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.DMS
{
    public class DmsRowIndex : Tuple<UInt16>
    {
        public DmsRowIndex(UInt16 item1) : base(item1)
        {
            if (item1 > 512)
                throw new ArgumentException();
        }
    }
}
