using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public class DataBufferEntry
    {
        public virtual uint endTimeBuffer
        {
            get;
            set;
        }

        public virtual UInt16 volumeDataBuffer
        {
            get;
            set;
        }

        public virtual UInt16 percentOccupancyBuffer
        {
            get;
            set;
        }

        public virtual UInt16 speedDataBuffer
        {
            get;
            set;
        }

        public virtual ZoneStatus zoneStatusBuffer
        {
            get;
            set;
        }
    }
}
