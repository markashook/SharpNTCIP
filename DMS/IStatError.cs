using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{

    [Flags]
    public enum SystemError
    {
        other = 1,
        communications = 2,
        power = 4,
        attachedDevice = 8,
        lamp = 16,
        pixel = 32, 
        photocell = 64,
        message = 128,
        controller = 256,
        temperature = 512,
        fan = 1024
    }

    public enum PixelTestActivation
    {
        other = 1,
        noTest = 2,
        test = 3, 
        clearTable = 4
    }

    public enum TestActivation
    {
        other = 1,
        noTest = 2,
        test = 3
    }

    [Flags]
    public enum ControllerError
    {
        other = 1,
        prom = 2,
        programOrProcessor = 4,
        ram = 8
    }

    /// <summary>
    /// Supports DMS sign message error status functions that are common 
    /// to DMS devices.
    /// </summary>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7")]
    public interface IStatError
    {
        /// <summary>
        /// Current system errors
        /// </summary>
        /// <remarks>
        /// This value is an OR'd set of SystemError enum values
        /// </remarks>
        /// <seealso cref="SystemError"/>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.1.0")]
        SystemError shortErrorStatus
        {
            get;
        }

        /// <summary>
        /// The number of rows contained in the pixelFailureTable each 
        /// indicating failed pixels
        /// </summary>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.2.0")]
        UInt16 pixelFailureTableNumRows
        {
            get;
        }

        /// <summary>
        /// A table containing the locations of failed pixels. 
        /// </summary>
        /// <remarks>
        /// The detection of pixel failures during message displays 
        /// shall be appended to the end of the table
        /// </remarks>
        PixelFailureTable pixelFailureTable
        {
            get;
        }

        /// <summary>
        /// Indicates the state of the pixel testing
        /// </summary>
        /// <remarks>
        /// The actual test routine can vary among different manufacturers. 
        /// The results of the pixel failure test shall be stored in the 
        /// pixel failure table. The pixel failure table will be cleared, 
        /// when a pixel test is started (test). Setting the value to test 
        /// will start the test, meaning this test will be executed once. 
        /// The sign controller will automatically set the value of this 
        /// object back to noTest after completion.
        /// </remarks>
        PixelTestActivation pixelTestActivation
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether each lamp within the sign is stuck on as a 
        /// bitmap. 
        /// </summary>
        /// <remarks>
        /// If a lamp is stuck on, its associated bit is set to one (1)
        /// </remarks>
        byte[] lampFailureStuckOn
        {
            get;
        }

        /// <summary>
        /// “Indicates whether each lamp within the sign is stuck off as a
        /// bitmap
        /// </summary>
        /// <remarks>
        /// If a lamp is stuck off, its associated bit is set to one (1)
        /// </remarks>
        byte[] lampFailureStuckOff
        {
            get;
        }

        /// <summary>
        /// Indicates the state of the lamp testing
        /// </summary>
        /// <remarks>
        /// The actual test routine can vary among different manufacturers. 
        /// The results of the lamp failure test shall be stored 
        /// appropriately, either in the lampFailureStuckOn- or in the 
        /// lampFailureStuckOff-objects. Setting the value to test will 
        /// start the test, meaning this test will be executed once. The 
        /// sign controller shall automatically set the value of this 
        /// object back to noTest after completion
        /// </remarks>
        TestActivation lampTestActivation
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates whether each fan (system) within a DMS is capable of 
        /// operating, expressed as a bitmap
        /// </summary>
        /// <remarks>
        /// If a fan (system) failed, its associated bit is set to one (1)
        /// </remarks>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.8.0")]
        byte[] fanFailures
        {
            get;
        }

        /// <summary>
        /// Indicates the state of the fan testing
        /// </summary>
        /// <remarks>
        /// The actual test routine can vary among different manufacturers. 
        /// The results of the fan test shall be stored in either the 
        /// fanFailures-objects. Setting the value to test will start the 
        /// test, meaning this test will be executed once. The sign 
        /// controller will automatically set the value of this object back 
        /// to noTest after completion
        /// </remarks>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.9.0")]
        TestActivation fanTestActivation
        {
            get;
            set;
        }

        /// <summary>
        /// A bitmap of controller related errors
        /// </summary>
        /// <remarks>
        /// This value is an OR'd set of ControllerError enum values
        /// If flag is set, then the associated error is existing; 
        /// if the flag is not set, then the associated error is not 
        /// existing
        /// </remarks>
        /// <seealso cref="ControllerError"/>
        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.10.0")]
        ControllerError controllerErrorStatus
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.11.0")]
        byte[] dmsPowerFailureStatusMap
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.12.0")]
        DmsRowIndex dmsPowerNumRows
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.13")]
        DmsPowerStatusTable dmsPowerStatusTable
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.14.0")]
        byte[] dmsClimateCtrlStatusMap
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.16.0")]
        DmsRowIndex dmsClimateCtrlNumRows
        {
            get;
        }

        [NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true),
        NtcipOid("1.3.6.1.4.1.1206.4.2.3.9.7.17")]
        DmsClimateCtrlStatusTable dmsClimateCtrlStatusTable
        {
            get;
        }

    }
}
