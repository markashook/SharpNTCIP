using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Used to group all DMS device-specific objects supporting 
    /// DMS sign timebased scheduling
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface ISchedule
    {
        /// <summary>
        /// Indicates the number of rows that are stored in the 
        /// dmsActionTable
        /// </summary>
        byte numActionTableEntries
        {
            get;
        }

        /// <summary>
        /// A table containing a list of message codes. The scheduler 
        /// will determine when a message shall be displayed. The 
        /// dayPlanTable of the scheduler points to a row in the table 
        /// to identify the message to be activated
        /// </summary>
        /// <seealso>
        /// TS3.4-1996, timebase-node
        /// </seealso>
        IDmsActionEntry[] dmsActionTable
        {
            get;
            set;
        }
    }
}
