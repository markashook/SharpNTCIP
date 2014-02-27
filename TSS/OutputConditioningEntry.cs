using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public enum SensorZoneOutputMode
    {
        other = 1, pulse = 2, presence = 3
    }

    public enum SensorZoneOutputDelayMode
    {
        delayEnablesHaveNoEffect = 1, delayEnablesORedActive = 2, delayEnablesORedNotActive = 3, dleayEnablesANDedActive = 4, delayEnablesANDedNotActive = 5
    }

    public enum SensorZoneOutputExtendMode
    {
        extendEnablesHaveNoEffect = 1, extendEnablesORedActive = 2, extendEnablesORedNotActive = 3, extendEnablesANDedActive = 4, extendEnablesANDedNotActive = 5
    }

    public abstract class OutputConditioningEntry
    {
        public abstract SensorZoneOutputMode sensorZoneOutputMode
        {
            get;
            set;
        }

        public abstract UInt16 sensorZoneMaxPresenceTime
        {
            get;
            set;
        }

        public abstract UInt16 sensorZoneOutputDelayTime
        {
            get;
            set;
        }

        public abstract SensorZoneOutputDelayMode sensorZoneOutputDelayMode
        {
            get;
            set;
        }

        public abstract bool[] sensorZoneOutputDelayEnables
        {
            get;
            set;
        }

        public abstract UInt16 sensorZoneOutputExtendTime
        {
            get;
            set;
        }

        public abstract SensorZoneOutputExtendMode sensorZoneOutputExtendMode
        {
            get;
            set;
        }

        public abstract bool[] sensorZoneOutputExtendEnables
        {
            get;
            set;
        }

        public abstract byte sensorZoneOutputSequenced
        {
            get;
            set;
        }
    }
}
