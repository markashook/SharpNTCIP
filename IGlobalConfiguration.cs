using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP
{
    /// <summary>
    /// This node is an identifier used to group all objects for support of configuration functions that are common to most device types
    /// TableType:              static
    /// NTCIP OID:              1.3.6.1.4.1.1206.4.2.6.1
    /// </summary>
    public interface IGlobalConfiguration
    {
        /// <summary>
        /// Specifies a relatively unique ID (e.g., this could be a counter, a check-sum, etc.) for all user-changeable parameters of the particular device-type currently implemented in the device. Often this ID is calculated using a CRC algorithm. This value shall be calculated when a change of any static database object has occurred. The value reported by this object shall not change unless there has been a change in the static data since the last request. If the actual objects, which are to be included to create this object value, are not defined in the actual device-level standard such as 1202 or 1203, then the general guidance is to include all configuration objects that are stored in a type of memory that survives power outages. A management station can use this object to detect any change in the static database objects by monitoring this value after it has established a baseline.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.1")]
        [NtcipMandatory(false)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        UInt16 globalSetIDParameter
        {
            get;
        }

        /// <summary>
        /// The number of rows that are listed in the globalModuleTable.  
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.2")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        uint globalMaxModules
        {
            get;
        }

        /// <summary>
        /// A table containing information regarding manufacturer
        /// of software and hardware and the associated module models and
        /// version numbers as well as an indicator if the module is hardware
        /// or software related. The number of rows in this table shall equal
        /// the value of the globalMaxModules object
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.none)]
        Table<Tuple<uint>, ModuleTableEntry> globalModuleTable
        {
            get;
        }
    }
}
