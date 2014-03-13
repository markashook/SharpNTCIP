using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Indicates the source of power
    /// </summary>
    public enum PowerSource
    {
        /// <summary>
        /// method not listed below (see device manual)
        /// </summary>
        other = 1,
        /// <summary>
        /// there is just enough power to perform shutdown activities.
        /// </summary>
        powerShutdown = 2,
        /// <summary>
        /// sign controller has power but the sign display has no power
        /// </summary>
        noSignPower = 3,
        /// <summary>
        /// controller and sign is powered by AC power
        /// </summary>
        acLine = 4,
        /// <summary>
        /// sign and the controller are powered by a generator
        /// </summary>
        generator = 5,
        /// <summary>
        /// sign and the controller are powered by solar equipment
        /// </summary>
        solar = 6,
        /// <summary>
        /// sign and controller are powered by battery with no significant 
        /// charging occurring
        /// </summary>
        battery = 7
    }
    
    /// <summary>
    /// Supports monitoring DMS sign power status
    /// </summary>
    public interface IStatPower
    {
        /// <summary>
        /// A voltage measurement in units of hundredth (1/100) of a volt
        /// </summary>
        /// <remarks>
        /// The maximum value (0xFFFF) corresponds to a voltage of 655.35 
        /// volts. This is an indication of the sign battery voltage.
        /// </remarks>
        UInt16 signVolts
        {
            get;
        }

        /// <summary>
        /// Indicates the low fuel level threshold used to alert the user. 
        /// </summary>
        /// <remarks>
        /// The threshold is indicated as a percent (%) of a full tank. 
        /// When the level of fuel is below the threshold, the bit for 
        /// power alarm (bit 2) in the shortErrorStatus-object shall be 
        /// set to one (1).
        /// </remarks>
        byte lowFuelThreshold
        {
            get;
            set;
        }

        /// <summary>
        /// A number indicating the amount of fuel remaining.
        /// </summary>
        /// <remarks>
        /// Specified as a percent (%) of full (0-100)
        /// </remarks>
        byte fuelLevel
        {
            get;
        }

        /// <summary>
        /// Indicates the engine rpm in units of 100. 
        /// </summary>
        /// <remarks>
        /// This provides a range from 0 rpm to 25500 rpm
        /// </remarks>
        byte engineRPM
        {
            get;
        }

        /// <summary>
        /// The DMS line voltage measurement in (1.0) volts
        /// </summary>
        /// <remarks>
        /// The range is 0 volts to 255 volts
        /// </remarks>
        byte lineVolts
        {
            get;
        }

        /// <summary>
        /// Indicates the source of power that is currently utilized by 
        /// the sign
        /// </summary>
        PowerSource powerSource 
        { 
            get; 
        }
    }
}
