using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Objects for support of VMS sign configurations that are 
    /// common to all VMS devices.
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2")]
    public interface IVmsCfg
    {
        /// <summary>
        /// Indicates the height of a single character in Pixels. 
        /// The value zero (0) Indicates a variable character height
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.1.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        byte vmsCharacterHeightPixels
        {
            get;
        }

        /// <summary>
        /// Indicates the width of a single character in Pixels. 
        /// The value zero (0) indicates a variable character width
        /// </summary>
        /// <remarks>A full matrix sign is indicated by a height and 
        /// width of zero (0). A line matrix sign is indicated by a 
        /// width of zero (0)</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.2.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        byte vmsCharacterWidthPixels
        {
            get;
        }

        /// <summary>
        /// Indicates the number of rows of pixels for the entire sign
        /// </summary>
        /// <remarks>To determine the number of lines for a line matrix 
        /// or character matrix sign, divide the vmsSignHeightPixels 
        /// object value by the vmsCharacterHeightPixels object value. 
        /// This should result in a whole number, the number of lines 
        /// for the sign</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.3.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        UInt16 vmsSignHeightPixels
        {
            get;
        }

        /// <summary>
        /// Indicates the number of columns of pixels for the entire sign
        /// </summary>
        /// <remarks>To determine the number of characters for a 
        /// character matrix sign, divide the vmsSignWidthPixels object 
        /// value by the vmsCharacterWidthPixels object value. This 
        /// should result in a whole number, the number of characters 
        /// per line for the sign.</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.4.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        UInt16 vmsSignWidthPixels
        {
            get;
        }

        /// <summary>
        /// Indicates the horizontal distance from the center of one pixel to the center of the neighboring pixel in millimeters
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.5.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        byte vmsHorizontalPitch
        {
            get;
        }

        /// <summary>
        /// Indicates the vertical distance from the center of one 
        /// pixel to the center of the neighboring pixel in 
        /// millimeters
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.6.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        byte vmsVerticalPitch
        {
            get;
        }

        /// <summary>
        /// Indicates the color supported by a monochrome sign. If the 
        /// 'monochrome1Bit' or 'monochrome8Bit' scheme is used, then 
        /// this object will contain six octets. The first 3 octets shall, 
        /// in this order, indicate the red, green, and blue component values 
        /// of the color when the pixels are turned 'ON'. The last 3 octets 
        /// shall, in this order, indicate the red, green, and blue component 
        /// values of the color when the pixels are turned 'OFF'.
        /// 
        /// If the sign is a non-monochrome sign, then the value of this 
        /// object shall be an octet string of six zeros 
        /// (0x00 0x00 0x00 0x00 0x00 0x00).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.2.7.0")]
        [NtcipAccess(NtcipAccessAttribute.Access.read)]
        [NtcipMandatory(true)]
        byte[] monochromeColor
        {
            get;
        }

    }
}
