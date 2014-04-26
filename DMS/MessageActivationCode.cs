using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace SharpNTCIP.DMS
{
    /// TODO: ENSURE ENDIANNESS

    /// <summary>
    /// bit 0 is the most significant bit (msb) of the most significant byte (MSB)
    /// </summary>
    /// <see cref="NTCIP 1203:1997"/>
    public class MessageActivationCode : MessageIDCode
    {
        public MessageActivationCode()
        {
            idCodeOffset = 3;
        }

        public MessageActivationCode(byte[] raw) : this()
        {
            decode(raw);
        }

        public MessageActivationCode(UInt16 duration, byte activatePriority, 
            DmsMessageMemoryType dmsMessageMemoryType, UInt16 dmsMessageNumber, 
            UInt16 dmsMessageCRC, IPAddress sourceAddress) : this()
        {
            Duration = duration;
            MsgMemoryType = dmsMessageMemoryType;
            MessageNumber = dmsMessageNumber;
            MessageCRC = dmsMessageCRC;
            ActivatePriority = activatePriority;
            SourceAddress = sourceAddress;
        }

        public MessageActivationCode(UInt16 duration, MessageIDCode idCode,
            byte activatePriority, IPAddress sourceAddress) :
            this(duration, activatePriority, idCode.MsgMemoryType, 
            idCode.MessageNumber, idCode.MessageCRC, sourceAddress) { }
        
        public MessageActivationCode(IDmsMessageEntry entry, UInt16 duration,
            byte activatePriority, IPAddress sourceAddress) :
            this(duration, activatePriority, entry.dmsMessageMemoryType, 
            entry.dmsMessageNumber, entry.dmsMessageCRC, sourceAddress) { }

        public override void decode(byte[] raw)
        {
            if (raw.Length != 12)
                throw new ArgumentException();

            _data = raw;
        }

        /// <summary>
        /// The maximum amount of time the message may be displayed prior 
        /// to activating the dmsDefaultEndDurationMessage. 
        /// DmsMsgTimeRemaining shall be set to this value upon successful 
        /// display of the indicated message. A Value of 65535 shall 
        /// indicate an infinite duration
        /// </summary>
        public ushort Duration
        {
            get
            {
                return BitConverter.ToUInt16(_data.Take(2).Reverse().ToArray(), 0);
            }
            set
            {
                byte[] val = BitConverter.GetBytes(value).Reverse().ToArray();
                _data[0] = val[0];
                _data[1] = val[1];
            }
        }

        /// <summary>
        /// If this value is greater than the dmsMsgRunTimePriority of the
        /// currently displayed message, the new message shall be displayed
        /// unless errors are detected.
        /// </summary>
        public byte ActivatePriority
        {
            get { return _data[2]; }
            set { _data[2] = value; }
        }

        /// <summary>
        /// the 4-byte IP address of the device which requested the 
        /// activation. The dmsActivateMsgError object shall be used to 
        /// indicate the success or failure of activating any message 
        /// requested by an object of MessageActivationCode SYNTAX
        /// </summary>
        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(_data.Skip(8).Take(4).Reverse().ToArray());
            }
            set
            {
                byte[] val = value.GetAddressBytes().Reverse().ToArray();
                for (int i = 0; i < 4; i++)
                    _data[i+8] = val[i];
            }
        }


    }
}
