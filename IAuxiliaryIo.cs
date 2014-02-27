using System;
using System.Collections.Generic;
using System.Text;
using SharpNTCIP.DMS;

namespace SharpNTCIP
{
    /// <summary>
    /// Used to control all objects supporting auxiliary IO
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    interface IAuxiliaryIo
    {
        /// <summary>
        /// The number of rows contained in the ‘auxIOTable’ with 
        /// the auxPortType set to ‘digital’.
        /// </summary>
        byte maxAuxIODigital
        {
            get;
        }

        /// <summary>
        /// The number of rows contained in the ‘auxIOTable’ with 
        /// the auxPortType set to ‘analog’
        /// </summary>
        byte maxAuxIOAnalog
        {
            get;
        }

        /// <summary>
        /// A table providing the means to access the auxiliary I/O 
        /// of the Controller, this includes reading inputs and setting 
        /// outputs. A maximum of 255 auxiliary IOs can be defined for 
        /// all, digital, analog or other types of ports
        /// </summary>
        IAuxIoEntry[] auxIOTable
        {
            get;
        }
    }
}
