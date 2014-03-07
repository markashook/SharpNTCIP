using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    public enum PixelFailureDetectionType
    {
        other = 1,
        pixelTest = 2, 
        messageDisplay = 3
    }

    [Flags]
    public enum PixelFailureStatus
    {
        stuckOff = 0,
        stuckOn = 1,
        colorError = 2,
        electricalError = 4,
        mechanicalError = 8
    }

    /// <summary>
    /// An entry containing the location of a failed pixel
    /// </summary>
    /// <seealso>NTCIP 1203:1997 -- National Transportation Communications 
    /// for ITS Protocol (NTCIP) Object Definitions for Dynamic Message 
    /// Signs (DMS)</seealso>
    public interface IPixelFailureEntry
    {
        /// <summary>
        /// Indicates the type of test/display that leads to the pixel 
        /// failure entry
        /// </summary>
        PixelFailureDetectionType pixelFailureDetectionType
        {
            get;
        }

        /// <summary>
        /// The index of the failed pixel in an enumeration of pixel 
        /// entries
        /// </summary>
        UInt16 pixelFailureIndex
        {
            get;
        }

        /// <summary>
        /// Indicates the X location of the failed pixel. 
        /// </summary>
        /// <remarks>
        /// The X direction is the horizontal direction. The X location is 
        /// counted from the left-most pixel in number of pixels
        /// </remarks>
        UInt16 pixelFailureXLocation
        {
            get;
        }

        /// <summary>
        /// Indicates the Y location of the failed pixel. 
        /// </summary>
        /// <remarks>
        /// The Y direction is the vertical direction. The Y location is 
        /// counted from the top-most pixel in number of pixels
        /// </remarks>
        UInt16 pixelFailureYLocation
        {
            get;
        }

        /// <summary>
        /// Indicates the current status of the specified pixel and the 
        /// operation which made this determination
        /// </summary>
        /// <remarks>
        /// This value is an OR'd set of PixelFailureStatus enum values
        /// </remarks>
        /// <seealso cref="PixelFailureStatus"/>
        byte pixelFailureStatus
        {
            get;
        }
    }
}
