using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// This node is an identifier used to group all objects for DMS sign 
    /// configurations that are common to all DMS devices
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IDms : IGlobalConfiguration
    {
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IDmsSignConfig dmsSignCfg
        {
            get;
        }

        /// <summary>
        /// Objects for support of VMS sign configurations that are 
        /// common to all VMS devices.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IVmsCfg vmsCfg
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IFontDefinition fontDefinition
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4"),
        NtcipAccess(NtcipAccessAttribute.Access.none),
        NtcipMandatory(true)]
        IMultiConfig multiCfg
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IDmsMessage dmsMessage
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        ISignControl signControl
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.7"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IIllumination illum
        {
            get;
        }

        [NtcipOid(""),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        ISchedule dmsSchedule
        {
            get;
        }

        [NtcipOid(""),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IDmsStatus dmsStatus
        {
            get;
        }
    }
}
