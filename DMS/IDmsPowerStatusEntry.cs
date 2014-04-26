using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.DMS
{
    public enum DmsPowerStatus
    {
        other               = 1,
        noError             = 2,
        powerFail           = 3,
        voltageOutOfSpec    = 4,
        currentOutOfSpec    = 5
    }

    public enum DmsPowerType
    {
        other       = 1,
        acLine      = 2,
        generator   = 3,
        solar       = 4,
        battery_UPS = 5,
        ledSupply   = 6,
        lampSupply  = 7
    }

    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1")]
    public interface IDmsPowerStatusEntry
    {

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.1.{0}")]
        DmsRowIndex dmsPowerIndex
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.2.{0}")]
        String dmsPowerDescription
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.3.{0}")]
        String dmsPowerMfrStatus
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.4.{0}")]
        DmsPowerStatus dmsPowerStatus
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.5.{0}")]
        UInt16 dmsPowerVoltage
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13.1.6.{0}")]
        DmsPowerType dmsPowerType
        {
            get;
        }
    }
}
