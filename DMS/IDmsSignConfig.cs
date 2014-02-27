using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Indicates the access method to a sign. These may be added 
    /// together to indicate more than one method of entry.
    /// </summary>
    public enum DMSAccess
    {
        /// <summary>
        /// Other
        /// </summary>
        Other = 1,
        /// <summary>
        /// Walk-in access
        /// </summary>
        WalkInAccess = 2,
        /// <summary>
        /// Rear access
        /// </summary>
        RearAccess = 4,
        /// <summary>
        /// Front access
        /// </summary>
        FrontAccess = 8
    }

    /// <summary>
    /// Indicates the type of a sign
    /// </summary>
    public enum DMSType
    {
        /// <summary>
        /// Device not specified through any other definition
        /// Refer to device manual
        /// </summary>
        other = 1,
        /// <summary>
        /// Device is a Blank-Out Sign
        /// </summary>
        bos = 2,
        /// <summary>
        /// Device is a Changeable Message Sign
        /// </summary>
        cms = 3,
        /// <summary>
        /// Device is a Variable Message Sign with character matrix setup
        /// </summary>
        vmsChar = 4,
        /// <summary>
        /// Device is a Variable Message Sign with line matrix setup
        /// </summary>
        vmsLine = 5,
        /// <summary>
        /// Device is a Variable Message Sign with full matrix setup
        /// </summary>
        vmsFull = 6,
        /// <summary>
        /// Device is portable but not specified through any other definition, 
        /// Refer to device manual
        /// </summary>
        portableOther = 128 + DMSType.other,
        /// <summary>
        /// Device is a Changeable Message Sign
        /// </summary>
        portableBOS = 128 + DMSType.bos,
        /// <summary>
        /// Device is a Portable Variable Message Sign with character matrix setup
        /// </summary>
        portableCMS = 128 + DMSType.cms,
        /// <summary>
        /// Device is a Portable Variable Message Sign with line matrix setup
        /// </summary>
        portableVMSChar = 128 + DMSType.vmsChar,
        /// <summary>
        /// Device is a Portable Variable Message Sign with line matrix setup
        /// </summary>
        portableVMSLine = 128 + DMSType.vmsLine,
        /// <summary>
        /// Device is a Portable Variable Message Sign with full matrix setup
        /// </summary>
        portableVMSFull = 128 + DMSType.vmsFull
    }

    /// <summary>
    /// Indicates the configuration of the type, numbers and 
    /// flashing patterns of beacons on a sign
    /// </summary>
    public enum DmsBeaconType
    {
        /// <summary>
        /// Other types, numbers and patterns of beacons on a sign supported by the device
        /// </summary>
        other = 1, 
        /// <summary>
        /// Patterns of beacons not supported by the device
        /// </summary>
        none = 2,
        /// <summary>
        /// 1 beacon flashing
        /// </summary>
        oneBeacon = 3,
        /// <summary>
        /// 2 beacons, synchronized flashing
        /// </summary>
        twoBeaconSyncFlash = 4,
        /// <summary>
        /// 2 beacons, opposing flashing
        /// </summary>
        twoBeaconsOppFlash = 5,
        /// <summary>
        /// 4 beacons, synchronized flashing
        /// </summary>
        fourBeaconSyncFlash = 6,
        /// <summary>
        /// 4 beacons, alternate row flashing
        /// </summary>
        fourBeaconAltRowFlash = 7,
        /// <summary>
        /// 4 beacons, alternate column flashing
        /// </summary>
        fourBeaconAltColumnFlash = 8,
        /// <summary>
        /// 4 beacons, alternate diagonal flashing
        /// </summary>
        fourBeaconAltDiagonalFlash = 9,
        /// <summary>
        /// 4 beacons, no synchronized flashing
        /// </summary>
        fourBeaconNoSyncFlash = 10,
        /// <summary>
        /// 1 beacon, strobe light
        /// </summary>
        oneBeaconStrobe = 11,
        /// <summary>
        /// two beacons, strobe light
        /// </summary>
        twoBeaconStrobe = 12,
        /// <summary>
        /// 4 beacons, strobe light
        /// </summary>
        fourBeaconStrobe = 13
    }

    /// <summary>
    /// Indicates if a Legend is shown on the sign
    /// </summary>
    public enum DmsLegend
    {
        /// <summary>
        /// Some unspecified configuration exists
        /// </summary>
        other = 1,
        /// <summary>
        /// The sign displays no legend
        /// </summary>
        noLegend = 2,
        /// <summary>
        /// The sign displays a legend
        /// </summary>
        legendExists = 3
    }

    /// <summary>
    /// Indicates the utilized technology in a bitmap format 
    /// Hybrids will have to set the bits for all technologies that the sign utilizes.
    /// </summary>
    public enum DmsSignTechnology
    {
        other = 1,
        led = 2,
        flipDisk = 4,
        fiberOptics = 8,
        shuttered = 16,
        lamp = 32,
        drum = 64
    }

    /// <summary>
    /// Dynamic Message Sign (DMS) object interface. Instances used to query 
    /// and/or control DMS devices shall implement this interface
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1")]
    public interface IDmsSignConfig
    {
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.1.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DMSAccess dmsSignAccess
        {
            get;
        }

        /// <summary>
        /// Indicates the type of sign
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.2.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DMSType dmsSignType
        {
            get;
        }

        /// <summary>
        /// Indicates the sign height in millimeters
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.3.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsSignHeight
        {
            get;
        }

        /// <summary>
        /// Indicates the Sign width in millimeters.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.4.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsSignWidth
        {
            get;
        }

        /// <summary>
        /// Indicates the minimum border distance, in millimeters, 
        /// that exists on the left and right sides of the sign.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.5.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsHorizontalBorder
        {
            get;
        }

        /// <summary>
        /// Indicates the minimum border distance, in millimeters, 
        /// that exists on the top and bottom of the sign.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.6.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsVerticalBorder
        {
            get;
        }

        /// <summary>
        /// Indicates if a Legend is shown on the sign
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.7.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsLegend dmsLegend
        {
            get;
        }

        /// <summary>
        /// Indicates the configuration of the type, numbers and 
        /// flashing patterns of beacons on the sign
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.8.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsBeaconType dmsBeaconType
        {
            get;
        }

        /// <summary>
        /// Indicates the utilized technology in a bitmap format 
        /// (Hybrids will have to set the bits for all technologies that the sign utilizes)
        /// If a bit is set to one (1), then the associated feature exists; if the bit is set to 
        /// zero (0), then the associated feature does not exist
        /// </summary>
        /// <seealso cref="DmsSignTechnology"/>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.1.9.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsSignTechnology dmsSignTechnology
        {
            get;
        }
    }
}
