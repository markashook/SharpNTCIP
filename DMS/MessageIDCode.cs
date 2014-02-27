using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Parameters required to define a message within a dmsMessageTable
    /// </summary>
    /// <see cref="NTCIP 1203:1997"/>
    public class MessageIDCode
    {
        /// <summary>
        /// The dmsMsgMemoryType of the desired message.
        /// </summary>
        byte MsgMemoryType
        {
            get;
            set;
        }

        /// <summary>
        /// The dmsMsgNumber of the desired message
        /// </summary>
        UInt16 MessageNumber
        {
            get;
            set;
        }

        /// <summary>
        /// The dmsMsgMessageCRC of the desired message
        /// </summary>
        UInt16 MessageCRC
        {
            get;
            set;
        }

    }
}
