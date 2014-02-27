using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// bit 0 is the most significant bit (msb) of the most significant byte (MSB)
    /// 
    /// </summary>
    /// <see cref="NTCIP 1203:1997"/>
    public class MessageActivationCode_raw : MessageIDCode
    {
        /// <summary>
        /// The maximum amount of time the message may be displayed prior 
        /// to activating the dmsDefaultEndDurationMessage. 
        /// DmsMsgTimeRemaining shall be set to this value upon successful 
        /// display of the indicated message. A Value of 65535 shall 
        /// indicate an infinite duration
        /// </summary>
        UInt16 Duration
        {
            get;
            set;
        }

        /// <summary>
        /// If this value is greater than the dmsMsgRunTimePriority of the
        /// currently displayed message, the new message shall be displayed
        /// unless errors are detected.
        /// </summary>
        byte ActivatePriority
        {
            get;
            set;
        }

        /// <summary>
        /// the 4-byte IP address of the device which requested the 
        /// activation. The dmsActivateMsgError object shall be used to 
        /// indicate the success or failure of activating any message 
        /// requested by an object of MessageActivationCode SYNTAX
        /// </summary>
        UInt32 SourceAddress
        {
            get;
            set;
        }
    }
}
