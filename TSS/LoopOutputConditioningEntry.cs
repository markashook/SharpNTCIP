using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    enum ZoneOutputMode
    {
        other=1,
        pulse,
        presence
    }
    
    public abstract class LoopOutputConditioningEntry
    {
        ZoneOutputMode zoneOutputMode
        {
            get;
            set;
        }

        UInt16 zoneMaxPresenceTime
        {
            get;
            set;
        }

        UInt16 zoneOutputDelayTime
        {
            get;
            set;
        }

        UInt16 zoneOutputExtendTime
        {
            get;
            set;
        }

        BinaryEnabled[] zoneOutputExtendEnable
        {
            get;
            set;
        }

        BinaryEnabled[] zoneOutputDelayEnable
        {
            get;
            set;
        }
    }
}
