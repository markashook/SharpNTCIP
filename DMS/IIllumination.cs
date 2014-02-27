using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Indicates methods used to select Brightness Level
    /// </summary>
    public enum IlluminationControl
    {
        /// <summary>
        /// The Brightness Level is set by some other method
        /// </summary>
        other = 1,
        /// <summary>
        /// The Brightness Level is based on photocell status
        /// </summary>
        photocell = 2,
        /// <summary>
        /// The Brightness Level is set by an internal timer
        /// </summary>
        timer = 3,
        /// <summary>
        /// the Brightness Level must be changed via the 
        /// dmsIllumManLevelobject
        /// </summary>
        manual = 4
    }

    /// <summary>
    /// Error type encountered when brightness table is set
    /// </summary>
    public enum IlluminationBrightnessValuesError
    {
        other = 1,
        none = 2,
        photocellGap = 3,
        negativeSlope = 4,
        tooManyLevels = 5,
        invalidData = 6
    }

    /// <summary>
    /// Used to group all objects supporting DMS sign illumination 
    /// functions that are common to DMS devices
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>

    public interface IIllumination
    {
        /// <summary>
        /// Indicates the method used to select the Brightness Level
        /// </summary>
        /// <remarks>
        /// When switching to manual mode from any other mode, 
        /// the current brightness level shall automatically be 
        /// loaded into the dmsIllumManLevel object
        /// </remarks>
        IlluminationControl dmsIllumControl
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the maximum value given by the 
        /// dmsIllumPhotocellLevelStatus-object
        /// </summary>
        UInt16 dmsIllumMaxPhotocellLevel
        {
            get;
        }

        /// <summary>
        /// Indicates the level of Ambient Light as a value 
        /// ranging from 0 (darkest) to the value of 
        /// dmsIllumMaxPhotocellLevel- object (brightest), based 
        /// on the photocell detection
        /// </summary>
        UInt16 dmsIllumPhotocellLevelStatus
        {
            get;
        }

        /// <summary>
        /// Indicates the number of individually selectable 
        /// Brightness Levels supported by the device, excluding 
        /// the OFF level
        /// </summary>
        byte dmsIllumNumBrightLevels
        {
            get;
        }

        /// <summary>
        /// Indicates the current Brightness Level of the device, 
        /// ranging from 0 (OFF) to the maximum value given by 
        /// the dmsIllumNumBrightLevels- object (Brightest)
        /// </summary>
        byte dmsIllumBrightLevelStatus
        {
            get;
        }

        /// <summary>
        /// Indicates the desired value of the Brightness Level 
        /// as a value ranging from 0 to the value of the 
        /// dmsIllumNumBrightLevels-object when under manual control
        /// </summary>
        byte dmsIllumManLevel
        {
            get;
            set;
        }

        /// <summary>
        /// An byte array describing the sign's Brightness Level in 
        /// relationship to the Photocell(s) detection of ambient 
        /// light. For each brightness level, there is a 
        /// corresponding range of photocell levels. The number 
        /// of levels transmitted is defined by the first byte of 
        /// the datapacket, but cannot exceed the value of the 
        /// dmsIllumNumBrightLevels object
        /// </summary>
        /// <remarks>
        /// After a SET, an implementation may interpolate these 
        /// entries to create a table with as many entries as 
        /// needed. For each level, there are three 16-bit values
        /// that occur in the following order: Brightness point,
        /// Photocell level down, Photocell level up. The
        /// Brightness point is a value between 0 (no light
        /// output) and 65535 (maximum light output). Each step
        /// is 1/65535 of the maximum light output (linear scale).
        /// The Photocell-level-down is the lowest photocell 
        /// level for this brightness level. Should the photocell
        /// level go below this point, the automatic brightness
        /// level would go down one level. The Photocell-level-up
        /// is the highest photocell level for this brightness 
        /// level. Should the photocell level go above this point,
        /// the automatic brightness level would go up one level.
        /// The photocell level (Up and Down) values may not
        /// exceed the value of the dmsIllumMaxPhotocellLevel 
        /// object.
        /// 
        /// The points transmitted should be selected so that there is 
        /// no photocell level which does not have a brightness level.
        /// Hystersis is possible by defining the photocell-level-up 
        /// at a level higher than the upper level's 
        /// photocell-level-down.
        /// </remarks>
        /// 
        /// <example>
        /// 0 1 2 3
        /// 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1
        /// +-+-+-+-+-+-+-+-+
        /// |NumEntries = n |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// | Brightness level 1 | Photocell-Level-Down point 1 |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// | Photocell-Level-Up point 1 | Brightness level 2 |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// | Photocell-Level-Down point 2 | Photocell-Level-Up point 2 |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        ///
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// | Photocell-Level-Down point n | Photocell-Level-Up point n |
        /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        /// </example>
        byte[] dmsIllumBrightnessValues
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the error encountered when the brightness table 
        /// was last set
        /// </summary>
        IlluminationBrightnessValuesError dmsIllumBrightnessValuesError
        {
            get;
        }

        /// <summary>
        /// Indicates the current physical light output value ranging 
        /// from 0 (darkest) to 65535 (maximum output)
        /// </summary>
        UInt16 dmsIllumLightOutputStatus
        {
            get;
        }
    }
}
