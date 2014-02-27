using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.DMS
{
    public enum FontStatus
    {
        notUsed = 1, ///This row is currently not used
        modifying = 2, ///The objects defined in this row can be modified
        calculatingID = 3, ///The fontVersionID is currently being calculated
        readyForUse = 4, ///Can be used for message display
        inUse = 5, ///Currently being used for the displayed message.
        permanent = 6, ///Permanent font that cannot be modified
        modifyReq = 7, ///A command has been sent to request transition to the modifying state
        readyForUseReq = 8, ///A command has been sent to request transition to the readyForUse state
        notUsedReq = 9, ///A command has been sent to request the transition to the notUsed state
        unmanagedReq = 10, ///A command has been sent to request the transition to the unmanaged state
        unmanaged = 11 ///Is not managed using the fontStatus object. Manage font as defined by NTCIP 1203 v1
    }

    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1")]
    public interface IFontEntry
    {
        /// <summary>
        /// Indicates the row number of the entry
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.1.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte fontIndex
        {
            get;
        }

        /// <summary>
        /// A unique, user-specified number for a particular font which 
        /// can be different from the value of the fontIndex-object. This 
        /// is the number referenced by MULTI when specifying a particular 
        /// font.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.2.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte fontNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the name of the font.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.3.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        string fontName
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the height of the font in pixels. Changing the value 
        /// of this object invalidates this fontTable row, sets all 
        /// corresponding characterWidth objects to zero (0), and sets all 
        /// corresponding characterBitmap objects to zero length. Character 
        /// Matrix and Line Matrix VMS shall subrange this object either to 
        /// a value of zero (0) or the value of vmsCharacterHeightPixels; a 
        /// Full Matrix VMS shall subrange this object to the range of zero 
        /// (0) to the value of vmsSignHeightPixels or 255, whichever is 
        /// less.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.4.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte fontHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default horizontal spacing (in pixels) between 
        /// each of the characters within the font. If the font changes on 
        /// a line, then the average character spacing of the two fonts, 
        /// rounded up to the nearest whole pixel, shall be used between 
        /// the two characters where the font changes. Character Matrix VMS 
        /// shall ignore the value of this object; Line Matrix and Full 
        /// Matrix VMS shall subrange this object to the range of zero (0) 
        /// to the smaller of 255 or the value of vmsSignWidthPixels.
        /// </summary>
        /// <seealso>See also the MULTI tag 'spacing character [sc]'.</seealso>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.5.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte fontCharSpacing
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default vertical spacing (in pixels) between each 
        /// of the lines within the font for Full Matrix VMS. The line 
        /// spacing for a line is the largest font line spacing of all fonts 
        /// used on that line. The number of pixels between adjacent lines is 
        /// the average of the 2 line spacings of each line, rounded up to 
        /// the nearest whole pixel. Character Matrix VMS and Line Matrix VMS 
        /// shall ignore the value of this object; Full Matrix VMS shall 
        /// subrange this object to the range of zero (0) to the smaller of 
        /// 255 or the value of vmsSignHeightPixels.
        /// </summary>
        /// <seealso>the MULTI tag 'new line [nl]'.</seealso>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.6.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte fontLineSpacing
        {
            get;
            set;
        }

        /// <summary>
        /// Each font that has been downloaded to a sign shall have a 
        /// relatively unique ID. This ID shall be calculated using the 
        /// CRC-16 algorithm defined in ISO 3309 and the associated 
        /// OER-encoded (as defined in NTCIP 1102) FontVersionByteStream. 
        /// 
        /// The sign shall respond with the version ID value that is valid at 
        /// the time.
        /// </summary>
        /// <see>NTCIP 1204v03-04 Part 1, Chapter 5.4.2.7</see>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.7.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 fontVersionID
        {
            get;
        }

        /// <summary>
        /// This object defines a state machine allowing to manage fonts 
        /// stored within a DMS
        /// </summary>
        /// <seealso cref="FontStatus"/>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.3.2.1.8.{0}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        FontStatus fontStatus
        {
            get;
            set;
        }
    }
}
