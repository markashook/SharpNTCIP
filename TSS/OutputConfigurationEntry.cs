using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    enum OutputFailsafeMode
    {
        failsafeModeOn = 1,
        failsafeModeOff,
        overrideCommandOn,
        overrideCommandOff,
        normal = 5
    }

    enum OutputArmingMode
    {
        armingEnablesHaveNoEffect = 1,
        normOffArmingEnablesORedZone,
        normOnArmingEnablesORedZone,
        normZoneArmingEnablesORedOff,
        normZoneArmingEnablesORedOn,
        normOffArmingEnablesANDedZone,
        normOnArmingEnablesANDedZone,
        normZoneArmingEnablesANDedOff,
        normZoneArmingEnablesANDedOn
    }

    public abstract class OutputConfigurationEntry
    {
        UInt16 outputNumber
        {
            get;
            set;
        }

        UInt16 outputSensorZoneNumber
        {
            get;
            set;
        }

        OutputFailsafeMode outputFailsafeMode
        {
            get;
            set;
        }

        bool[] outputModeStatus
        {
            get;
            set;
        }

        string outputLabel
        {
            get;
            set;
        }

        bool[] outputArmingEnables
        {
            get;
            set;
        }

        OutputArmingMode outputArmingMode
        {
            get;
            set;
        }
    }
}
