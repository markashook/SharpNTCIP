using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public enum SensorSystemResetStatus
    {
        restart = 1, reinitializeUserSettings, restoreFactoryDefaults, retune, resyncSamplingPeriods, shortDiagnostics, fullDiagnostics, executePendingConfiguration, abortPendingConfiguration, validatePendingConfiguration, noResetInProgress
    }

    public enum SensorSystemStatus
    {
        other = 1, oK, initializing, pendingConfigurationChange, validatingPendingConfiguration, diagError, activeConfigError, pendingConfigError
    }

    public enum SensorSystemOccupancyType
    {
        normalizedOtherOccupancy = 1, nonNormalizedOccupancy, zoneOccupancy, normalizedSixFoorLoopOccupancy, normalizedTwoMeterLoopOccupancy, normalizedPointOccupancy
    }

    public enum SensorTechnology
    {
        other = 1, inductiveLoop = 2, machineVision = 3
    }

    public interface ITSSSystemSetup
    {
        SensorSystemResetStatus sensorSystemReset
        {
            get;
            set;
        }

        SensorSystemStatus sensorSystemStatus
        {
            get;
        }

        SensorSystemOccupancyType sensorSystemOccupancyType
        {
            get;
        }

        UInt16 maxSensorZones
        {
            get;
        }

        List<SensorZoneEntry> sensorZoneTable
        {
            get;
            set;
        }

        bool clockAvailable
        {
            get;
        }

        SensorTechnology sensorTechnology
        {
            get;
        }

        UInt16 maxSampleDataEntries
        {
            get;
        }

        UInt16 maxNumberOfCharacters
        {
            get;
        }

        bool[] functionalCapabilities
        {
            get;
        }

        bool[] externalArmingInputs
        {
            get;
            set;
        }

        List<OutputConditioningEntry> outputConditioningTable
        {
            get;
            set;
        }

        string pendingConfigurationFileName
        {
            get;
            set;
        }
    }
}
