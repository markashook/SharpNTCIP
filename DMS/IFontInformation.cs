using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// FontInformation describes the characteristics of the font which 
    /// are common to each character and defines the order in which this 
    /// information appears when constructing the byte stream which will 
    /// be used to calculate the CRC
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IFontInformation
    {
        /// <summary>
        /// A unique, user-specified number for a particular font which 
        /// can be different from the value of the fontIndex-object. 
        /// This is the number referenced by MULTI when specifying a 
        /// particular font. A device shall return a 
        /// GeneralErrorException if this 
        /// value is not unique
        /// </summary>
        int fontNumber
        {
            get;
        }

        /// <summary>
        /// Indicates the height of the font in pixels. Setting this 
        /// object to zero (0) invalidates this fontTable row, and also 
        /// invalidates all corresponding entries into the characterTable
        /// </summary>
        int fontHeight
        {
            get;
        }

        /// <summary>
        /// Indicates the default horizontal spacing (in pixels) between
        /// each of the characters within the font. This object only
        /// applies to Full Matrix and Line Matrix VMS. If the font
        /// changes on a line, then the average value of the two fonts
        /// shall be used between sequential characters. Character Matrix
        /// VMS shall either set this object to zero (0), or not support
        /// this object
        /// </summary>
        int fontCharSpacing
        {
            get;
        }

        /// <summary>
        /// Indicates the default vertical spacing (in pixels) between
        /// each of the lines within the font. This object only applies
        /// to Full Matrix. The line spacing for a line is the largest
        /// font line spacing of all fonts used on that line. The number
        /// of pixels between adjacent lines is the average of the line
        /// spacings of each line. Character Matrix VMS and Line Matrix
        /// VMS shall either set this object to zero (0), or not support
        /// this object
        /// </summary>
        int fontLineSpacing
        {
            get;
        }

    }
}
