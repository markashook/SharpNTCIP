using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.4.1")]
    public interface ICharacterEntry
    {
        /// <summary>
        /// Indicates the binary value associated with this character 
        /// of this font. For example, if the font set followed the 
        /// ASCII numbering scheme, the character giving the bitmap 
        /// of ‘A’ would be characterNumber 65 (41 hex)
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.4.1.1.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 characterNumber
        {
            get;
        }

        /// <summary>
        /// Indicates the width of this character in pixels. 
        /// A width of zero (0) indicates this row is invalid
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.4.1.2.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte characterWidth
        {
            get;
            set;
        }

        /// <summary>
        /// A bitmap that defines each pixel within a rectangular 
        /// region as being either ON (bit=1) or OFF (bit=0). The
        /// result of this bitmap is how the character appears on the
        /// sign.</summary>
        /// <remarks>The octet string is treated as a binary bit string.
        /// The most significant bit defines the state of the pixel in
        /// the upper left corner of the rectangular region. The
        /// rectangular region is processed by rows, left to right,
        /// then top to bottom. The size of the rectangular region is
        /// defined by the fontHeight and characterWidth objects. After
        /// the rectangular region is defined, any remaining bits shall
        /// be zero (0).</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.4.1.3.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte[] characterBitmap
        {
            get;
            set;
        }

    }
}
