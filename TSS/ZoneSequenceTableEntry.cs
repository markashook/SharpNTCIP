using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public abstract class ZoneSequenceTableEntry
    {
        UInt16 numSampleDataEntries
        {
            get;
            set;
        }

        UInt16 numSensorZoneClass
        {
            get;
            set;
        }
    }
}
