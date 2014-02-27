using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    /// <summary>
    /// Contains sensor zone unit parameters.
    /// 
    /// Reference:          NTCIP1209v0209
    /// </summary>
    public class SensorZoneEntry
    {
        public UInt32 sensorZoneNumber
        {
            get;
            set;
        }

        public bool sensorZoneOptions
        {
            get;
            set;
        }

        public bool sensorZoneOptionStatus
        {
            get;
            set;
        }

        public UInt16 sensorZoneSamplePeriod
        {
            get;
            set;
        }

        public string sensorZoneLabel
        {
            get;
            set;
        }

        public UInt64 sensorZoneOperator
        {
            get;
            set;
        }

        public UInt64 sensorZoneOrOperator
        {
            get;
            set;
        }

        public byte sensorZonePairedZone
        {
            get;
            set;
        }

        public byte sensorZonePairedZoneOptions
        {
            get;
            set;
        }

        public UInt16 sensorZoneSpeedCorrectionFactor
        {
            get;
            set;
        }

        public UInt16 sensorZoneAvgVehicleLength
        {
            get;
            set;
        }

        public UInt16 sensorZoneLength
        {
            get;
            set;
        }

        public ZoneStatus sensorZoneStatus
        {
            get;
            set;
        }
    }
}
