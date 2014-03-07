using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Used to group all objects for DMS font configurations 
    /// that are common to DMS device
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3")]
    public interface IFontDefinition
    {
        /// <summary>
        /// Indicates the maximum number of fonts that the 
        /// sign can store
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.1.0")]
        byte numFonts
        {
            get;
        }

        /// <summary>
        /// A table containing the information needed to 
        /// configure/define a particular font
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2")]
        FontTable fontTable
        {
            get;
        }

        /// <summary>
        /// Indicates the maximum number of rows in the character table that can exist for any given font
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.3.0")]
        UInt16 maxFontCharacters
        {
            get;
        }

        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.4")]
        CharacterTable characterTable
        {
            get;
        }

    }
}
