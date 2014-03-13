using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Supports monitoring DMS sign temperature status
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IStatTemp
    {
        /// <summary>
        /// Indicates the current temperature, single sensor, or the 
        /// current minimum temperature, multiple sensors, within the DMS 
        /// Control Cabinet in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMinCtrlCabinet
        {
            get;
        }

        /// <summary>
        /// Indicates the current temperature, single sensor, or the 
        /// current maximum temperature, multiple sensors, within the DMS 
        /// Control Cabinet in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMaxCtrlCabinet
        {
            get;
        }

        /// <summary>
        /// Indicates the current outside ambient temperature, single 
        /// sensor, or the current minimum outside ambient temperature, 
        /// multiple sensors in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMinAmbient
        {
            get;
        }

        /// <summary>
        /// Indicates the current outside ambient temperature, single 
        /// sensor, or the current maximum outside ambient temperature, 
        /// multiple sensors in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMaxAmbient
        {
            get;
        }

        /// <summary>
        /// Indicates the current temperature, single sensor, or the 
        /// current minimum temperature, multiple sensors in the sign 
        /// housing in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMinSignHousing
        {
            get;
        }

        /// <summary>
        /// Indicates the current temperature, single sensor, or the 
        /// current maximum temperature, multiple sensors in the sign 
        /// housing in degrees Celsius
        /// </summary>
        /// <remarks>
        /// Supports values from -128 to 127 degrees Celsius
        /// </remarks>
        Int16 tempMaxSignHousing
        {
            get;
        }

    }
}
