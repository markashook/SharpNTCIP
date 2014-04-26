using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.DMS
{
    public class PixelFailureTable : Table<Tuple<PixelFailureDetectionType, UInt16>, IPixelFailureEntry>
    {
    }
}
