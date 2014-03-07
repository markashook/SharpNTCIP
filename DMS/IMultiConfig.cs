using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Each of the background colors on a sign should map to one 
    /// of the colors listed. If a color is requested that is not
    /// supported, then a GeneralErrorException shall be returned
    /// </summary>
    public enum SignColor
    {
        black = 0,
        red = 1,
        yellow = 2,
        green = 3,
        cyan = 4,
        blue = 5,
        magenta = 6,
        white = 7,
        orange = 8,
        amber = 9
    }

    public enum HorizontalJustification
    {
        other = 1,
        left = 2,
        center = 3,
        right = 4,
        full = 5
    }

    public enum VerticalJustification
    {
        other = 1,
        top = 2,
        middle = 3,
        bottom = 4
    }

    public enum DmsColorScheme
    {
        monochrome1bit = 1,
        monochrome8bit = 2,
        colorClassic = 3,
        color24bit = 4
    }

    [Flags]
    public enum DmsSupportedMultiTags
    {
        none                        = 0,
        color_background            = 1 << 0,
        color_goreground            = 1 << 1,
        flashing                    = 1 << 2,
        font                        = 1 << 3,
        graphic                     = 1 << 4,
        hexadecimal_character       = 1 << 5,
        justification_line          = 1 << 6,
        justification_page          = 1 << 7,
        manufacturer_specific       = 1 << 8,
        moving_text                 = 1 << 9,
        new_line                    = 1 << 10,
        new_page                    = 1 << 11,
        page_time                   = 1 << 12,
        spacing_character           = 1 << 13,
        field_local_time_12_hour    = 1 << 14,
        field_local_time_24_hour    = 1 << 15,
        ambient_temperature_c       = 1 << 16,
        ambient_temperature_f       = 1 << 17,
        speed_kmph                  = 1 << 18,
        speed_mph                   = 1 << 19,
        day_of_week                 = 1 << 20,
        date_of_month               = 1 << 21,
        month_of_year               = 1 << 22,
        year_2_digits               = 1 << 23,
        year_4_digits               = 1 << 24,
        local_time_12_hour_AMPM     = 1 << 25,
        local_time_12_hour_ampm     = 1 << 26,
        text_rectangle              = 1 << 27,
        color_rectangle             = 1 << 28,
        page_background             = 1 << 29
    }

    /// <summary>
    /// The intent of this object is to provide a mechanism by which 
    /// 16-bit character sets (and potentially other character sets) 
    /// can be supported in a future version. Currently, this object 
    /// only provides a standard for 8-bit character encoding
    /// </summary>
    public enum CharacterNumberEncoding
    {
        /// <summary>
        /// A character size is something other than those 
        /// listed below, refer to the device manual
        /// </summary>
        other = 1,
        /// <summary>
        /// Each characterNumber of a given font is encoded 
        /// as an 8-bit value
        /// </summary>
        eightBit = 2
    }

    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4")]
    public interface IMultiConfig
    {
        /// <summary>
        /// Indicates the color of the background shown on the sign
        /// </summary>
        /// <remarks>Each of the background colors on a sign should map 
        /// to one of the colors listed. If a color is requested that
        /// is not supported, then a GeneralErrorException shall be 
        /// returned</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.1.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        SignColor defaultBackgroundColor
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the color of the foreground (the actual text) 
        /// shown on the sign
        /// </summary>
        /// <remarks>Each of the colors on a sign should map to one 
        /// of the colors listed. If a color is requested that is not 
        /// supported, then a GeneralErrorException shall be returned
        /// </remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.2.0"),
        NtcipAccess(NtcipAccessAttribute.Access.none),
        NtcipMandatory(true)]
        SignColor defaultForegroundColor
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default flash on time, in tenths of a 
        /// second, for flashing text. If the time is set to zero (0), 
        /// the default is NO FLASHing but the text remains visible
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.3.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte defaultFlashOn
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default flash off time, in tenths of a second, 
        /// for flashing text. If the time is set to zero (0), the 
        /// default is NO FLASHing but the text remains visible
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.4.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte defaultFlashOff
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default font number (fontNumber-object) 
        /// for a message
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.5.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte defaultFont
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default line justification for a message
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.6.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        HorizontalJustification defaultJustificationLine
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default page justification for a message
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.7.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        VerticalJustification defaultJustificationPage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default page on time, in tenths (1/10) 
        /// of a second. If the message is only one page, this 
        /// value is ignored, and the page is continuously 
        /// displayed
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.8.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte defaultPageOnTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default page off time, in tenths (1/10)
        /// of a second. If the message is only one page, this 
        /// value is ignored, and the page is continuously 
        /// displayed
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.9.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte defaultPageOffTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the default number of bits used to define a single 
        /// character in a MULTI string.
        ///   other (1): - a character size other than those listed below, 
        ///     refer to the device manual.
        ///   eightBit (2): - each characterNumber of a given font is 
        ///     encoded as an 8-bit value.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.10.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        CharacterNumberEncoding defaultCharacterSet
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the color scheme supported by the DMS. The values are defined as:
        /// monochrome1bit (1): - Only two states are available for each pixel: 
        ///   on (1) and off (0). A value of 'on (1)' shall indicate that the 
        ///   defaultForegroundRGB is used and value of 'off(0)' shall indicate that 
        ///   the defaultBackgroundRGB is used.
        /// monochrome8bit (2): - this color palette supports 256 shades ranging from 
        ///   0 (off) to 255 (full intensity). Values between zero and 255 are scaled 
        ///   to the nearest intensity level supported by the VMS. Therefore, it is 
        ///   not required that a VMS have true 8-bit (256 shade) capabilities.
        /// colorClassic (3): - the following values are available:
        ///   black (0),
        ///   red (1),
        ///   yellow (2),
        ///   green(3),
        ///   cyan (4),
        ///   blue (5),
        ///   magenta (6),
        ///   white (7),
        ///   orange (8),
        ///   amber (9).
        /// color24bit (4): - Each pixel is defined by three bytes, one each for red, 
        ///   green, and blue. Each color value ranges from 0 (off) to 255 (full 
        ///   intensity). The combination of the red, green, and blue colors equals 
        ///   the 16,777,216 number of colors. DMS with dmsColorScheme set to 
        ///   color24bit shall interpret MULTI tags with a single color parameter 
        ///   (e.g. [cfx]) as colorClassic
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.11.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsColorScheme dmsColorScheme
        {
            get;
        }

        /// <summary>
        /// Indicates the color of the background shown on the sign if not 
        /// changed by the ‘Page Background Color’ MULTI tag or the ‘Color 
        /// Rectangle’ MULTI tag. The values are expressed in values appropriate
        /// to the color scheme indicated by the dmsColorScheme object. When 
        /// the 'color24bit' scheme is used, then this object contains three 
        /// octets. When 'color24bit' is used, then the object value contains 
        /// 3 octets (first octet = red, second = green, third = blue).
        /// When 'monochrome1bit' is used, the value of this octet shall be 
        /// either 0 or 1. When 'monochrome8bit' is used, the value of this 
        /// octet shall be 0 to 255. In either the 'monochrome1bit' or 
        /// 'monochrome8bit' scheme, the actual color is indicated in the 
        /// monochromeColor object. When 'colorClassic' is used, the value of 
        /// this octet shall be the value of the classic color.
        /// If the ‘colorClassic’ value (see dmsColorScheme object) is used, 
        /// both defaultBackgroundColor and defaultBackgroundRGB objects shall 
        /// return the same value if queried by a central system.. Each of the 
        /// background colors on a sign shall map to one of the colors in the 
        /// color scheme of the sign.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.12.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte[] defaultBackgroundRGB
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the color of the foreground shown on the sign unless 
        /// changed by the ‘Color Foreground’ MULTI tag. This is the color 
        /// used to illuminate the ‘ON’ pixels of displayed characters. 
        /// The values are expressed in values appropriate to the color 
        /// scheme indicated by the dmsColorScheme object. When the 
        /// 'color24bit' scheme is used, then this object contains three 
        /// octets (first octet = red, second = green, third = blue).
        /// When 'monochrome1bit' is used, the value of this octet shall 
        /// be either 0 or 1. When 'monochrome8bit' is used, the value of 
        /// this octet shall be 0 to 255. In either the 'monochrome1bit' or 
        /// 'monochrome8bit' scheme, the actual color is indicated in the 
        /// monochromeColor object. When 'colorClassic' is used, the value 
        /// of this octet shall be the value of the classic color.
        /// If the ‘colorClassic’ value (see dmsColorScheme object) is used, 
        /// both defaultForegroundColor and defaultForegroundRGB objects shall 
        /// return the same value if queried by a central system.
        /// Each of the foreground colors on a sign shall map to one of the 
        /// colors in the color scheme of the sign.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.13.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
        NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte[] defaultForegroundRGB
        {
            get;
            set;
        }

        /// <summary>
        /// An indication of the MULTI Tags supported by the device. 
        /// This object is a bitmap representation of tag support. 
        /// When a bit is set (=1), the device supports the 
        /// corresponding tag. When a bit is cleared (=0), the device 
        /// does not support the corresponding tag.
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.14.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsSupportedMultiTags dmsSupportedMultiTags
        {
            get;
        }

        /// <summary>
        /// Indicates the maximum number of pages allowed in the 
        /// dmsMessageMultiString
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.15.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte dmsMaxNumberPages
        {
            get;
        }

        /// <summary>
        /// Indicates the maximum number of bytes allowed within the 
        /// dmsMessageMultiString
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.16.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte dmsMaxMultiStringLength
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultFlashOn at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.17.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte defaultFlashOnActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultFlashOff at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.18.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte defaultFlashOffActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultFont at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.19.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte defaultFontActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultJustificationLine at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.20.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        HorizontalJustification defaultJustificationLineActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultJustificationPage at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.21.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        VerticalJustification defaultJustificationPageActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultPageOnTime at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.22.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte defaultPageOnTimeActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultPageOffTime at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.23.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte defaultPageOffTimeActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultBackgroundRGB at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.24.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte[] defaultBackgroundRGBActivate
        {
            get;
        }

        /// <summary>
        /// Indicates the value of defaultForegroundRGB at activation of 
        /// the currently active message for the purpose of determining 
        /// what the value was at the time of activation. The value shall 
        /// be created (overwritten) at the time when the message was 
        /// copied into the currentBuffer
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.4.25.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        byte[] defaultForegroundRGBActivate
        {
            get;
        }
    }
}
