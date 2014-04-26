using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SharpNTCIP;
using System.Security.Cryptography;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Parameters required to define a message within a dmsMessageTable
    /// </summary>
    /// <see cref="NTCIP 1203:1997"/>
    public class MessageIDCode
    {
        protected byte[] _data;
        protected int idCodeOffset = 0;

        public MessageIDCode()
        {
            _data = new byte[5];
        }

        public MessageIDCode(byte[] raw) : this()
        {
            decode(raw);
        }

        public MessageIDCode(DmsMessageMemoryType dmsMessageMemoryType, 
            UInt16 dmsMessageNumber, UInt16 dmsMessageCRC) : this()
        {
            MsgMemoryType = dmsMessageMemoryType;
            MessageNumber = dmsMessageNumber;
            MessageCRC = dmsMessageCRC;
        }

        public MessageIDCode(IDmsMessageEntry entry) : 
            this(entry.dmsMessageMemoryType, entry.dmsMessageNumber, 
            entry.dmsMessageCRC) { }

        public virtual void decode(byte[] raw)
        {
            if (raw.Length-idCodeOffset < 5)
                throw new ArgumentException();
            Buffer.BlockCopy(raw,0,_data,idCodeOffset,5);
        }

        public byte[] encode()
        {
            byte[] bytes = new byte[5];
            Array.Copy(_data,idCodeOffset,bytes,0,5);
            return bytes;
        }

        /// <summary>
        /// The dmsMsgMemoryType of the desired message.
        /// </summary>
        public DmsMessageMemoryType MsgMemoryType
        {
            get
            {
                if (_data[0] != 0)
                    return (DmsMessageMemoryType)_data[0];
                throw new IndexOutOfRangeException();
            }
            set
            {
                _data[0] = (byte)value;
            }
        }

        /// <summary>
        /// The dmsMsgNumber of the desired message
        /// </summary>
        public UInt16 MessageNumber
        {
            get
            {
                return BitConverter.ToUInt16(_data.Skip(1).Take(2).Reverse().ToArray(),0);
            }
            set
            {
                var val = BitConverter.GetBytes(value);
                _data[idCodeOffset+1] = val[1];
                _data[idCodeOffset+2] = val[0];
            }
        }

        /// <summary>
        /// The dmsMsgMessageCRC of the desired message
        /// </summary>
        public UInt16 MessageCRC
        {
            get
            {
                return BitConverter.ToUInt16(_data.Skip(3).Take(2).Reverse().ToArray(),0);
            }
            set
            {
                var val = BitConverter.GetBytes(value);
                _data[idCodeOffset+3] = val[1];
                _data[idCodeOffset+4] = val[0];
            }
        }
    }
}
