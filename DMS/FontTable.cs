using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.DMS
{
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2")]
    class FontTable : Table<Tuple<int>, IFontEntry>
    {
    }
}
