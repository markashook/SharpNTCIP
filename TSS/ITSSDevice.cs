using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    enum BinaryEnabled
    {
        Disabled = 0,
        Enabled = 1
    }

    public interface ITSSDevice : IGlobalConfiguration
    {
        ITSSSystemSetup tssSystemSetup
        {
            get;
        }

        ITSSControl tssControl
        {
            get;
        }

        DataCollection tssDataCollection
        {
            get;
        }

        ITSSInductiveLoop tssInductiveLoop
        {
            get;
        }

        ITSSMachineVision tssMachineVision
        {
            get;
        }
    }
}
