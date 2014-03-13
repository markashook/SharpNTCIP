using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Supports DMS sign status monitoring functions common to DMS devices
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IDmsStatus
    {
        /// <summary>
        /// Indicates the number of rows in the statMultiFieldTable 
        /// that are currently being used
        /// </summary>
        byte statMultiFieldRows
        {
            get;
        }

        StatMultiFieldTable statMultiFieldTable
        {
            get;
        }

        /// <summary>
        /// Used to retrieve the current speed value as detected by 
        /// the attached device. The speed is transmitted in kilometers 
        /// per hour (km/h). This value may vary from the displayed speed 
        /// value due to application specific implementation
        /// </summary>
        byte dmsCurrentSpeed
        {
            get;
        }

        /// <summary>
        /// Indicates the current speed limit in kilometers per hour (km/h)
        /// </summary>
        byte dmsCurrentSpeedLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the number of watchdog failures that have occurred
        /// </summary>
        int watchdogFailureCount
        {
            get;
        }

        /// <summary>
        /// Indicates whether any of the doors to the controller cabinet 
        /// or the sign housing are open. This is a bitmap; if a bit is 
        /// set (= 1) then the door is open; if a bit not is not set, then 
        /// the associated door is closed
        /// </summary>
        byte dmsStatDoorOpen
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign message error status
        /// </summary>
        IStatError statError
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign power status
        /// </summary>
        IStatPower statPower
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign temperature status
        /// </summary>
        IStatTemp statTemp
        {
            get;
        }
    }
}
