using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    enum ZoneSensitivityMode
    {
        deltaL = 1, deltaLOverSqrtL = 2, deltaLOverL = 3
    }

    enum SensorZoneLoopLayout
    {
        other = 1, 
        oneSixBySixLoopOneLane,
        twoSixBySixLoopsOneLane,
        threeSixBySixLoopsOneLane,
        fourSixBySixLoopsOneLane,
        oneLongLoopOneLane,
        oneSixBySixLoopsMultipleLanes
    }

    public abstract class LoopSensorSetupEntry
    {
        ZoneSensitivityMode zoneSensitivityMode
        {
            get;
            set;
        }

        bool[] zoneSensitivity
        {
            get;
            set;
        }

        bool[] zoneFrequencyRange
        {
            get;
            set;
        }

        SensorZoneLoopLayout sensorZoneLoopLayout
        {
            get;
            set;
        }
    }
}
