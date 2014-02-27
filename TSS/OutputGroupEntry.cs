using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public abstract class OutputGroupEntry
    {
        UInt16 outputGroupNumber
        {
            get;
            set;
        }

        bool[] outputGroupOutputState
        {
            get;
            set;
        }
    }
}
