using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    /// <summary>
    /// Node for TSS data collection elements
    /// 
    /// Reference:          NTCIP1209v0209
    /// </summary>
    public class DataCollection
    {
        public virtual Dictionary<int, DataCollectionEntry> dataCollectionTable
        {
            get;
            set;
        }

        public virtual Dictionary<int, DataBufferEntry> dataBufferTable
        {
            get;
            set;
        }

        public virtual Dictionary<int, List<ZoneSequenceTableEntry>> zoneSequenceTable
        {
            get;
            set;
        }

        public virtual Dictionary<SampleEntryNumber, List<SampleDataEntry>> sampleDataTable
        {
            get;
            set;
        }

        public virtual List<String> zoneClassTable
        {
            get;
            set;
        }
    }
}
