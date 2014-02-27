using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP
{

    public enum ModuleType
    {
        other = 1, hardware = 2, software = 3
    }

    /// <summary>
    /// This object defines an entry in the module table.
    /// NTCIP OID:              1.3.6.1.4.1.1206.4.2.6.1.3.1
    /// </summary>
    public class ModuleTableEntry
    {
        /// <summary>
        /// This object contains the row number (1..255) within
        /// this table for the associated module
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.1")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual uint moduleNumber
        {
            get { return moduleNumber; }
        }

        /// <summary>
        /// This object contains the device node number of the
        /// device-type, e.g., an ASC signal controller would have an OID of
        /// 1.3.6.1.4.1.1206.4.2.1
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.2")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual object moduleDeviceNode
        {
            get { return moduleDeviceNode; }
        }

        /// <summary>
        /// Definition>This object specifies the manufacturer of the
        /// associated module. A null-string shall be transmitted if this
        /// object has no entry.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.3")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual string moduleMake
        {
            get { return moduleMake; }
        }

        /// <summary>
        /// This object specifies the model number (hardware) or
        /// firmware reference (software) of the associated module. A nullstring
        /// shall be transmitted if this object has no entry.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.4")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual string moduleModel
        {
            get { return moduleModel; }
        }

        /// <summary>
        /// This object specifies the version of the associated
        /// module. If the moduleType has a value of software, the value of
        /// this object shall include the date on which the software was
        /// released as a string in the form of YYYYMMDD, it shall be followed
        /// by a space, a hyphen, another space, the lower-case letter ‘v’,
        /// followed by a version or configuration number. Preceding zeros
        /// shall be required for the date. For example, version 7.03.02 of
        /// the software released on July 5, 2002 would be presented as
        /// 20020705 – v7.03.02
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.5")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual string moduleVersion
        {
            get { return moduleVersion; }
        }

        /// <summary>
        /// This object specifies whether the associated module
        /// is a hardware or software module
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.3.1.6")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual ModuleType moduleType
        {
            get { return moduleType; }
        }

        /// <summary>
        /// For use in this object, an ASCII string that shall
        /// identify all of the standard document numbers that define or
        /// reference MIBs upon which the device is based. Where applicable,
        /// profiles shall be referenced rather than the base standards. The
        /// version string shall be constructed as follows: The acronym of the
        /// standards development organization (or other body) that developed
        /// and approved the standard; a space; the standards document number;
        /// a colon; and the documents version number as designated by the
        /// standards development organization (or other body). Separate
        /// entries in the list of standards shall be separated by a carriage
        /// return (0x0d) and line feed (0x0a).
        /// In the case of NTCIP documents prior to formal approval, the
        /// version number shall be the version number in the form of lower
        /// case ‘v’ followed by the major version followed by a period
        /// followed by the minor revision. In the case of approved NTCIP
        /// standards, the publication year shall precede the version number.
        /// In the case of amended NTCIP standards, the version number shall
        /// be replaced by the four digit year of publication of the published
        /// standard followed by the upper case letter ‘A’, followed by the
        /// amendment number.
        /// For example, a message sign may have the following value for this
        /// object:
        /// NTCIP 1201:v02.19
        /// NTCIP 1203:1997A1
        /// NTCIP 2101:2001 v01.19
        /// NTCIP 2103:v01.13
        /// NTCIP 2201:v01.14
        /// NTCIP 2301:2001 v01.08
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.6.1.4")]
        [NtcipMandatory(true)]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        public virtual string controllerBaseStandards
        {
            get { return controllerBaseStandards; }
        }
    }
}
