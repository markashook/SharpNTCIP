using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// Indicates the source that initiated the currently 
    /// displayed message
    /// </summary>
    public enum DmsControlMode
    {
        /// <summary>
        /// Other control mode supported by the device 
        /// (refer to device manual)
        /// </summary>
        other = 1,
        /// <summary>
        /// Local control mode
        /// </summary>
        local = 2,
        /// <summary>
        /// External control mode
        /// </summary>
        external = 3,
        /// <summary>
        /// Central control mode
        /// </summary>
        central = 4,
        /// <summary>
        /// Central station took control over Local control, 
        /// even though the control switch within the cabinet 
        /// was set to Local
        /// </summary>
        centralOverride = 5,
        /// <summary>
        /// Controller is in a mode where it accepts every command 
        /// and it pretends that it would execute them but this 
        /// does not happen because the controller only simulates
        /// </summary>
        simulation = 6
    }

    /// <summary>
    /// Allows the system to manage the device’s memory
    /// </summary>
    public enum DmsMemoryManagement
    {
        other = 1,
        normal = 2,
        clearChangeableMessages = 3,
        clearVolatileMessages = 4
    }

    /// <summary>
    /// This is an error code used to identify why a message was not 
    /// displayed.
    /// </summary>
    public enum ActivateMessageError
    {
        other = 1,
        none = 2,
        priority = 3,
        underValidation = 4,
        memoryType = 5,
        messageNumber = 6,
        messageCRC = 7,
        syntaxMULTI = 8,
        localMode = 9
    }

    /// <summary>
    /// This is an error code used to identify the first detected 
    /// syntax error within the MULTI message
    /// </summary>
    public enum MultiSyntaxError
    {
        /// <summary>
        /// An error other than one of those listed
        /// </summary>
        other = 1,
        /// <summary>
        /// No error detected
        /// </summary>
        none = 2,
        /// <summary>
        /// The referenced tag is not supported by this device
        /// </summary>
        unsupportedTag = 3,
        /// <summary>
        /// The referenced tag value is not supported by this device
        /// </summary>
        unsupportedTagValue = 4,
        /// <summary>
        /// Too many characters on a line and/or too many lines for 
        /// a page
        /// </summary>
        textTooBig = 5,
        /// <summary>
        /// The referenced font is not defined in this device
        /// </summary>
        fontNotDefined = 6,
        /// <summary>
        /// The referenced character is not defined in the selected 
        /// font
        /// </summary>
        characterNotDefined = 7,
        /// <summary>
        /// The referenced field device does not exist / is not 
        /// connected to this device
        /// </summary>
        fieldDeviceNotExist = 8,
        /// <summary>
        /// This device is not receiving input from the referenced 
        /// field device and/or the refererenced field device has 
        /// a fault
        /// </summary>
        fieldDeviceError = 9,
        /// <summary>
        /// The flashing region selected cannot be flashed by this device
        /// </summary>
        flashRegionError = 10,
        /// <summary>
        /// The message cannot be displayed with the combination of 
        /// tags and/or tag implementation cannot be resolved
        /// </summary>
        tagConflict = 11,
        /// <summary>
        /// Too many pages of text exists in the message
        /// </summary>
        tooManyPages = 12
    }

    /// <summary>
    /// Used to group all objects for support of DMS sign control 
    /// functions that are common to DMS devices
    /// </summary>
    public interface ISignControl
    {
        /// <summary>
        /// A value indicating the selected control mode of the sign
        /// </summary>
        DmsControlMode dmsControlMode
        {
            get;
            set;
        }

        /// <summary>
        /// A software interface to initiates a controller reset. 
        /// The execution of the controller reset shall set this 
        /// object to the value 0.
        /// </summary>
        /// <remarks>
        /// Value zero (0) = no reset, value one (1) = reset.
        /// </remarks>
        bool dmsSWReset
        {
            get;
            set;
        }

        /// <summary>
        /// A code indicating the message which the sign shall activate. 
        /// The dmsActivateMsgError object shall be set appropriately 
        /// when this object is SET. If a message activation error 
        /// occurs, the new message shall not be displayed and a 
        /// GeneralErrorException shall be returned.
        /// </summary>
        MessageActivationCode_raw dmsActivateMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the amount of remaining time in minutes that 
        /// the current message shall be displayed. The value 65535 
        /// indicates an infinite duration. A value of zero (0) 
        /// shall indicate that the current message display duration 
        /// has expired
        /// </summary>
        UInt16 dmsMessageTimeRemaining
        {
            get;
            set;
        }

        /// <summary>
        /// Identifies the message number used to generate the 
        /// currently displayed message. This object is written to 
        /// by the device when the new message is loaded into the 
        /// currentBuffer of the MessageTable. The currently 
        /// displayed message is stored in the currentBuffer, but 
        /// the information regarding which message number 
        /// generated the current message would be lost if not 
        /// indicated through this object
        /// </summary>
        MessageIDCode dmsMsgTableSource
        {
            get;
        }

        /// <summary>
        /// Indicates the time, in seconds, from the start of power 
        /// loss to the threshold where a short power loss becomes 
        /// a long power loss. If the value is set to zero (0), all 
        /// power failures are defined as long power losses
        /// </summary>
        UInt16 dmsShortPowerLossTime
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that is displayed after a Reset 
        /// (either software or hardware) of the device. This 
        /// assumes that the device can differentiate between a 
        /// reset and a power loss
        /// </summary>
        MessageIDCode dmsResetMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that is displayed after the loss 
        /// of communications to the device. If there is no default 
        /// message defined after the duration expires, then the 
        /// sign goes blank
        /// </summary>
        MessageIDCode dmsCommunicationsLossMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Defines the maximum time (inclusive), in minutes, 
        /// between successive Application Layer messages that 
        /// can occur before a communication loss is assumed. If 
        /// this object is set to zero (0), no communication loss 
        /// shall occur
        /// </summary>
        /// <remarks>
        /// This timer differs from the Data Link Layer timers 
        /// (T1 to T4). A dial-up circuit may have short time-outs
        /// at the DL Layer, but central might only dial up once a 
        /// month to confirm operation, in which case this object 
        /// would be set to ~ 35 days.
        /// </remarks>
        UInt16 dmsTimeCommLoss
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that is displayed DURING the loss 
        /// of power of the device
        /// </summary>
        MessageIDCode dmsPowerLossMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that is displayed after the 
        /// indicated duration for a message has expired and no 
        /// other Message had been assigned to replace the previous 
        /// Message
        /// </summary>
        MessageIDCode dmsEndDurationMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Allows the system to manage the device’s memory
        /// </summary>
        DmsMemoryManagement dmsMemoryMgmt
        {
            get;
            set;
        }

        /// <summary>
        /// This is an error code used to identify why a message 
        /// was not displayed. 
        /// </summary>
        /// <remarks>
        /// If multiple errors occur, only the latest value will 
        /// be indicated. The syntaxMULTI error is further 
        /// detailed in the dmsMultiSyntaxError, 
        /// dmsMultiSyntaxErrorPosition and 
        /// dmsMultiOtherErrorDescription objects
        /// </remarks>
        ActivateMessageError dmsActivateMsgError
        {
            get;
            set;
        }

        /// <summary>
        /// This is an error code used to identify the first 
        /// detected syntax error within the MULTI message
        /// </summary>
        MultiSyntaxError dmsMultiSyntaxError
        {
            get;
            set;
        }

        /// <summary>
        /// This is the offset from the first character (i.e. 
        /// first character has offset 0, second is 1, etc.) of 
        /// the MULTI message where the SYNTAX error occurred
        /// </summary>
        UInt16 dmsMultiSyntaxErrorPosition
        {
            get;
        }

        /// <summary>
        /// Indicates vendor-specified error message descriptions. 
        /// Associated errors occurred due to vendor-specific 
        /// MULTI-tag responses
        /// </summary>
        string dmsMultiOtherErrorDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the pixel service duration in seconds
        /// </summary>
        UInt16 vmsPixelServiceDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the pixel service cycle time (frequency) 
        /// in minutes (0-1440)
        /// </summary>
        UInt16 vmsPixelServiceFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the base time at which the first pixel 
        /// service shall occur. Time is expressed in minutes 
        /// from the epoch of Midnight of each day (0-1440)
        /// </summary>
        UInt16 vmsPixelServiceTime
        {
            get;
            set;
        }


    }
}
