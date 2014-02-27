using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public abstract class DataCollectionEntry
    {
        public uint endTime
        {
            get;
            set;
        }

        public UInt16 volumeData
        {
            get;
            set;
        }

        public UInt16 percentOccupancy
        {
            get;
            set;
        }

        public UInt16 speedData
        {
            get;
            set;
        }

        public ZoneStatus zoneStatus
        {
            get;
            set;
        }
    }
}
