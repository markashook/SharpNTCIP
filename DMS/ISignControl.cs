using System;
using System.Collections.Generic;
using System.Text;
using SharpNTCIP.Attributes;
using System.Net;

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
    /// Indicates the source that initiated the currently displayed message. 
    /// </summary>
    public enum DmsMsgSourceMode
    {
        /// <summary>
        /// the currently displayed message was activated based on a 
        /// condition other than the ones defined below. This would 
        /// include any auxiliary devices.
        /// </summary>
        other       = 1,
        /// <summary>
        /// the currently displayed message was activated at the sign 
        /// controller using either an onboard terminal or a local interface.
        /// </summary>
        local       = 2,
        /// <summary>
        /// the currently displayed message was activated from a locally 
        /// connected device using serial (or other type of) connection 
        /// to the sign controller such as a laptop or a PDA. This mode 
        /// shall only be used, if the sign controller is capable of 
        /// distinguishing between a local input (see definition of 
        /// 'local (2)') and a serial connection.
        /// </summary>
        external    = 3,
        otherCom1   = 4,
        otherCom2   = 5,
        otherCom3   = 6,
        otherCom4   = 7,
        /// <summary>
        /// the currently displayed message was activated from the 
        /// central computer.
        /// </summary>
        central     = 8,
        /// <summary>
        /// the currently displayed message was activated from the 
        /// timebased scheduler as configured within the sign controller.
        /// </summary>
        timebasedScheduler  = 9,
        /// <summary>
        /// the currently displayed message was activated based on the 
        /// settings within the dmsLongPowerRecoveryMessage, 
        /// dmsShortPowerRecoveryMessage, and the dmsShortPowerLossTime 
        /// objects.
        /// </summary>
        powerRecovery       = 10,
        /// <summary>
        /// the currently displayed message was activated based on the 
        /// settings within the dmsResetMessage object.
        /// </summary>
        reset               = 11,
        /// <summary>
        /// the currently displayed message was activated based on the 
        /// settings within the dmsCommunicationsLossMessage object.
        /// </summary>
        commLoss            = 12,
        /// <summary>
        /// the currently displayed message was activated based on the 
        /// settings within the dmsPowerLossMessage object. Note: it may 
        /// not be possible to point to this message depending on the 
        /// technology, e.g. it may not be possible to display a message 
        /// on pure LED or fiber-optic signs DURING power loss.
        /// </summary>
        powerLoss           = 13,
        /// <summary>
        /// the currently displayed message was activated based on the 
        /// settings within the dmsEndDurationMessage object.
        /// </summary>
        endDuration         = 14
    }

    /// <summary>
    /// Used to group all objects for support of DMS sign control 
    /// functions that are common to DMS devices
    /// </summary>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6")]
    public interface ISignControl
    {
        /// <summary>
        /// A value indicating the selected control mode of the sign
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.1.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.2.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.3.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        MessageActivationCode dmsActivateMessage
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.4.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.5.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        MessageIDCode dmsMsgTableSource
        {
            get;
        }

        /// <summary>
        /// A copy of the source-address field from the 
        /// dmsActivateMessage-object used to activate the current
        /// message. If the current message was not activated by the 
        /// dmsActivateMessage-object, then the value of this object 
        /// shall be zero (0).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.6.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        IPAddress dmsMsgRequesterID
        {
            get;
        }

        /// <summary>
        /// Indicates the source that initiated the currently 
        /// displayed message
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.7.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsMsgSourceMode dmsMsgSourceMode
        {
            get;
        }

        /// <summary>
        /// Indicates the message that shall be activated after a power
        /// recovery following a short power loss affecting the device 
        /// (see dmsActivateMessage). The message shall be activated with:
        /// – a duration of 65535 (infinite) (if this object points to a 
        ///   value of 'currentBuffer', the duration is determined by the 
        ///   value of the dmsMessageTimeRemaining object minus the power 
        ///   outage time);
        /// – an activation priority of 255;
        /// – a source address '127.0.0.1'.
        /// 
        /// Upon activation of the message, the run-time priority value 
        /// shall be obtained from the message table row specified by this 
        /// object.
        /// 
        /// The length of time that defines a short power loss is indicated 
        /// in the dmsShortPowerLossTime-object.
        /// 
        /// DEFVAL: 
        ///     MessageIDCode = 
        ///         messageMemoryType = 7, 
        ///         messageNumber = 1,
        ///         messageCRC = 0
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.8.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        MessageIDCode dmsShortPowerRecoveryMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that shall be activated after a power 
        /// recovery following a long power loss affecting the device 
        /// (see dmsActivateMessage). The message shall be activated with
        /// – a duration of 65535 (infinite), (if this object points to a 
        /// value of 'currentBuffer', the duration is determined by the 
        /// value of the dmsMessageTimeRemaining object minus the power 
        /// outage time)
        /// – an activation priority of 255;
        /// – a source address of '127.0.0.1'.
        /// 
        /// Upon activation of the message, the run-time priority value 
        /// shall be obtained from the message table row specified by this 
        /// object.
        /// 
        /// The length of time that defines a long power loss is indicated 
        /// in the dmsShortPowerLossTime-object.
        /// 
        /// DEFVAL 
        ///     MessageIDCode = 
        ///         messageMemoryType = 7, 
        ///         messageNumber = 1,
        ///         messageCRC = 0
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.9.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        MessageIDCode dmsLongPowerRecoveryMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the time, in seconds, from the start of power 
        /// loss to the threshold where a short power loss becomes 
        /// a long power loss. If the value is set to zero (0), all 
        /// power failures are defined as long power losses
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.10.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.11.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.12.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.13.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        UInt16 dmsTimeCommLoss
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the message that is displayed DURING the loss 
        /// of power of the device
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.14.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.15.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        MessageIDCode dmsEndDurationMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Allows the system to manage the device’s memory
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.16.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.17.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        ActivateMessageError dmsActivateMsgError
        {
            get;
            set;
        }

        /// <summary>
        /// This is an error code used to identify the first 
        /// detected syntax error within the MULTI message
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.18.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.19.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsMultiSyntaxErrorPosition
        {
            get;
        }

        /// <summary>
        /// Indicates vendor-specified error message descriptions. 
        /// Associated errors occurred due to vendor-specific 
        /// MULTI-tag responses
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.20.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        string dmsMultiOtherErrorDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the pixel service duration in seconds
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.21.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        UInt16 vmsPixelServiceDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the pixel service cycle time (frequency) 
        /// in minutes (0-1440)
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.22.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
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
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.6.23.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read | NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        UInt16 vmsPixelServiceTime
        {
            get;
            set;
        }


    }
}
