using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public interface ITSSInductiveLoop
    {
        List<LoopSensorSetupEntry> loopSensorSetupTable
        {
            get;
            set;
        }

        List<LoopOutputConditioningEntry> loopOutputConditioningTable
        {
            get;
            set;
        }

        List<LoopSystemStatusEntry> loopoSystemStatusTable
        {
            get;
            set;
        }
    }
}
