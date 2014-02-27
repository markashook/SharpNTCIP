using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public abstract class LoopSystemStatusEntry
    {
        UInt16 zoneInductance
        {
            get;
            set;
        }

        UInt32 zoneFrequency
        {
            get;
            set;
        }

        UInt32 zoneInductanceChange
        {
            get;
            set;
        }

        bool[] zoneFaultHistory
        {
            get;
            set;
        }

        UInt16 zoneFaultCount
        {
            get;
            set;
        }

        UInt32 zonePercentInductanceChange
        {
            get;
            set;
        }
    }
}
