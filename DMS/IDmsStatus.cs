using System;
using System.Collections.Generic;
using System.Text;
using SharpNTCIP.Attributes;

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
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.1.0")]
        byte statMultiFieldRows
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.2")]
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
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.3.0")]
        byte dmsCurrentSpeed
        {
            get;
        }

        /// <summary>
        /// Indicates the current speed limit in kilometers per hour (km/h)
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.4.0")]
        byte dmsCurrentSpeedLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the number of watchdog failures that have occurred
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.5.0")]
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
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.6.0")]
        byte dmsStatDoorOpen
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign message error status
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7")]
        IStatError statError
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign power status
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("")]
        IStatPower statPower
        {
            get;
        }

        /// <summary>
        /// Supports monitoring DMS sign temperature status
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("")]
        IStatTemp statTemp
        {
            get;
        }
    }
}
