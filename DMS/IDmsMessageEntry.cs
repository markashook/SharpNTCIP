using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    public enum DmsMessageMemoryType
    {
        /// <summary>
        /// any other type of memory type that is not listed 
        /// within one of the values below, refer to device manual;
        /// </summary>
        other = 1,
        /// <summary>
        /// non-volatile and non-changeable
        /// </summary>
        permanent = 2,
        /// <summary>
        /// non-volatile and changeable;
        /// </summary>
        changeable = 3,
        /// <summary>
        /// volatile and changeable
        /// </summary>
        volatile_ = 4,
        /// <summary>
        /// contains the information regarding the currently 
        /// displayed message. Only one entry in the table can 
        /// have the value of currentBuffer and the value of the 
        /// dmsMessageNumber object must be one (1)
        /// </summary>
        currentBuffer = 5,
        /// <summary>
        /// this entry contains information regarding the currently 
        /// scheduled message as determined by the time-base 
        /// scheduler (if present). Only one entry in the table can 
        /// have the value of ‘schedule’ and the dmsMessageNumber-
        /// object-value for this entry must be 1. This will be the 
        /// displayed message when the dmsMessageSourceMode is 
        /// timebasedScheduler
        /// </summary>
        schedule = 6
    }

    public enum MessageStatus
    {
        /// <summary>
        /// This is a state value and indicates that the row does
        /// not contain any valid message data. Controller memory
        /// may or may not be released to free memory pool in this
        /// state. Reading an object from a row when this object is
        /// set to notUsed in undetermined, i.e., last contents, or
        /// random data may be returned. Setting any object (except
        /// this object) for a row that is notUsed shall return a
        /// GeneralErrorException. The only valid command in this
        /// state is modifyReq
        /// </summary>
        notUsed = 1,
        /// <summary>
        /// This is a state value and indicates that the row is 
        /// being modified to define a message. Modifying any 
        /// objects (except this object) can only be done when the 
        /// row is in this state, otherwise a GenError shall be 
        /// returned. The valid commands in this state is 
        /// validateReq and notUsedReq.
        /// </summary>
        modifying = 2,
        /// <summary>
        /// This is a state value and indicates that the 
        /// controller is validating all of the message data for 
        /// the row. When validation is complete, the controller 
        /// will automatically change the state to either valid 
        /// (message data is good), or error (some error found 
        /// within the message data). The only valid command is 
        /// the notUsedReq command, which shall set the state to 
        /// notUsed or return a GeneralErrorException
        /// </summary>
        validating = 3,
        /// <summary>
        /// This is a state and indicates the message data is 
        /// valid and the message can be activated. Activation 
        /// of a message cannot occur in any other state. The 
        /// valid commands in this state are notUsedReq and 
        /// modifyReq
        /// </summary>
        valid = 4,
        /// <summary>
        /// This is a state and indicates that an error was 
        /// detected during the validation process. The valid 
        /// commands in this state are modifyReq and notUsedReq
        /// </summary>
        error = 5,
        /// <summary>
        /// This is a command that indicates the user wishes to 
        /// modify the row to define a message. A GenError may 
        /// be returned if the controller is in the notUsed 
        /// state and there is insufficient memory to define a 
        /// new message. A successful request will change the 
        /// state of the row to modifying. An unsuccessful 
        /// request will leave the row in the same state as it 
        /// was prior to the command. This command can be 
        /// issued while in the notUsed, valid and error states
        /// </summary>
        modifyReq = 6,
        /// <summary>
        /// This is a command that indicates the user wishes to 
        /// validate the current message data. This command can 
        /// only be issued while the row is in the modify state, 
        /// else a GenError shall be returned. A successful 
        /// request will change the state of the row to 
        /// validating. An unsuccessful request will leave the 
        /// row in the same state as it was prior to the command
        /// </summary>
        validateReq = 7,
        /// <summary>
        /// This is a command that indicates the user wishes to 
        /// end use of the current message data. This command 
        /// can be issued while the row is in the modify, 
        /// validating, valid, and error states. A successful 
        /// request will change the state of the row to notUsed. 
        /// An unsuccessful request will leave the row in the 
        /// same state as it was prior to the command
        /// </summary>
        notUsedReq = 8
    }

    public enum ValidateMessageError
    {
        other = 1,
        none = 2,
        beacons = 3,
        pixelService = 4,
        syntaxMULTI = 5
    }

    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1")]
    public interface IDmsMessageEntry
    {
        /// <summary>
        /// Indicates the memory-type used to store a message. 
        /// Also provides access to current message (currentBuffer) 
        /// and currently scheduled message (schedule).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.1.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        DmsMessageMemoryType dmsMessageMemoryType
        {
            get;
        }

        /// <summary>
        /// Enumerated listing of row entries within the value of 
        /// the primary index to this table (dmsMessageMemoryType 
        /// -object). When the primary index is ‘currentBuffer’ or 
        /// ‘schedule’, then this value must be one (1).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.2.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsMessageNumber
        {
            get;
        }

        /// <summary>
        /// Contains the message written in MULTI-language
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.3.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read | 
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        string dmsMessageMultiString
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the owner or author of this row
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.4.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
            NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        string dmsMessageOwner
        {
            get;
            set;
        }

        /// <summary>
        /// “Indicates the CRC-16 (polynominal defined in ISO/IEC 
        /// 3309) value created using the values of the 
        /// dmsMessageMultiString- (MULTI-Message), the 
        /// dmsMessageBeacon-, and the dmsMessagePixelService
        /// -objects in the order listed, not including the type
        /// or length fields
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.5.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsMessageCRC
        {
            get;
        }

        /// <summary>
        /// Indicates if connected beacon(s) are to be activated 
        /// when the associated message is displayed. </summary>
        /// <remarks>False (0) = Beacon(s) are Disabled ;
        /// true (1) = Beacon(s) are Enabled</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.6.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
        NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        bool dmsMessageBeacon
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether pixel service shall be enabled (1) 
        /// or disabled (0) while this message is active
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.7.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
        NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        bool dmsMessagePixelService
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the run time priority assigned to a 
        /// particular message. The value of 1 indicates the 
        /// lowest level, the value of 255 indicates the 
        /// highest level
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.8.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
        NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        byte dmsMessageRunTimePriority
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the current state of the message. This 
        /// state-machine allows for defining a message, 
        /// validating a message, and freeing message use.
        /// </summary>
        /// <remarks>The enumerated values can be divided 
        /// into two types, state values and command values. 
        /// State values can only be read, a GenErr shall 
        /// occur if a SET is attempted. Command values can 
        /// be written to, and will cause a state change if 
        /// accepted, and thus cannot be returned.</remarks>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8.1.9.{0}.{1}"),
        NtcipAccess(NtcipAccessAttribute.Access.read |
        NtcipAccessAttribute.Access.write),
        NtcipMandatory(true)]
        MessageStatus dmsMessageStatus
        {
            get;
            set;
        }
    }
}
