using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpNTCIP.Attributes;

namespace SharpNTCIP.DMS
{
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.2")]
    public class StatMultiFieldTable : Table<Tuple<byte>, IStatMultiFieldEntry>
    {
    }
}
