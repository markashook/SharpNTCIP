using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Indicates the type of auxiliary I/O
    /// </summary>
    public enum AuxIoPortType
    {
        other = 1,
        analog = 2,
        digital = 3
    }

    /// <summary>
    /// Indicates whether the state of a port can be set (output), read
    /// (input), or both (bidirectional)
    /// </summary>
    public enum AuxIoPortDirection
    {
        output = 1,
        input = 2,
        bidirectional = 3
    }

    /// <summary>
    /// A means to access the auxiliary I/O of a Controller, this 
    /// includes reading/setting input/output.
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IAuxIoEntry
    {
        /// <summary>
        /// Indicates the type of auxiliary I/O, which can be analog, 
        /// digital or other
        /// </summary>
        AuxIoPortType auxIOPortType
        {
            get;
        }

        /// <summary>
        /// Indicates the port number for the associated port type. 
        /// </summary>
        /// <remarks>
        /// Port numbers are used sequentially from one to max for 
        /// each port type. There can be a port 1 for analog port and 
        /// port 1 for digital port
        /// </remarks>
        byte auxIOPortNumber
        {
            get;
        }

        /// <summary>
        /// Informational text field describing the device at the 
        /// associated auxiliary I/O
        /// </summary>
        string auxIODescription
        {
            get;
            set;
        }

        /// <summary>
        /// Defines number of bits used for the IO-port
        /// </summary>
        /// <remarks>
        /// The width of digital, resolution of analog
        /// </remarks>
        byte auxIOResolution
        {
            get;
            set;
        }

        /// <summary>
        /// For input or bidirectional ports, this contains the current 
        /// value of the input. For output ports, this is the last 
        /// commanded value of the port. A genError shall be generated, 
        /// if this object is set and the port is an input
        /// </summary>
        uint auxIOValue
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether state of this port can be set (output), 
        /// read (input) or both (bidirectional)
        /// </summary>
        AuxIoPortDirection auxIOPortDirection
        {
            get;
            set;
        }
    }
}
