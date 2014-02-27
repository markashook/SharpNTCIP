using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IDmsActionEntry
    {
        /// <summary>
        /// Enumerated listing of row entries. The value of this 
        /// object cannot exceed the value of the numActionTableEntries -
        /// object.
        /// </summary>
        byte dmsActionIndex
        {
            get;
        }

        /// <summary>
        /// A number indicating the message memory type, the message 
        /// number and the associated message-specific CRC as indicated 
        /// within the message table
        /// </summary>
        MessageIDCode dmsActionMsgCode
        {
            get;
            set;
        }
    }
}
