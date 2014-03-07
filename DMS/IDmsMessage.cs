using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    /// <summary>
    /// This node is an identifier used to group all objects for support of DMS Message Table
    /// functions that are common to DMS devices.
    /// </summary>
    [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5")]
    public interface IDmsMessage
    {
        /// <summary>
        /// “Indicates the current number of Messages stored in 
        /// non-volatile, non-changeable memory (e.g., EPROM). 
        /// For CMS and BOS, this is the number of different 
        /// messages that can be assembled
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.1.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsNumPermanentMsg
        {
            get;
        }

        /// <summary>
        /// “Indicates the current number of Messages stored in 
        /// non-volatile, changeable memory. For CMS and BOS,
        /// this number shall be zero (0)
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.2.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsNumChangeableMsg
        {
            get;
        }

        /// <summary>
        /// Indicates the maximum number of Messages that the 
        /// sign can store in non-volatile, changeable memory. 
        /// For CMS and BOS, this number shall be zero (0).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.3.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsMaxChangeableMsg
        {
            get;
        }

        /// <summary>
        /// Indicates the number of bytes available within 
        /// non-volatile, changeable memory. For CMS and BOS, 
        /// this number shall be zero (0).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.4.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        uint dmsFreeChangeableMemory
        {
            get;
        }

        /// <summary>
        /// Indicates the current number of Messages stored in 
        /// volatile, changeable memory. For CMS and BOS, this 
        /// number shall be zero (0).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.5.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsNumVolatileMsg
        {
            get;
        }

        /// <summary>
        /// Indicates the maximum number of Messages that the 
        /// sign can store in volatile, changeable memory. For 
        /// CMS and BOS, this number shall be zero (0)
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.6.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        UInt16 dmsMaxVolatileMsg
        {
            get;
        }

        /// <summary>
        /// Indicates the number of bytes available within 
        /// volatile, changeable memory. For CMS and BOS, 
        /// this number shall be zero (0).
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.7.0"), 
        NtcipAccess(NtcipAccessAttribute.Access.read), 
        NtcipMandatory(true)]
        uint dmsFreeVolatileMemory
        {
            get;
        }

        /// <summary>
        /// A table containing the information needed to activate a Message on a sign. The values
        /// of a columnar object (except the dmsMessageStatus) cannot be changed when the ‘dmsMessageStatus’-
        /// object of that particular row has the value of ‘valid’
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.8"),
        NtcipAccess(NtcipAccessAttribute.Access.none),
        NtcipMandatory(true)]
        DmsMessageTable dmsMessageTable
        {
            get;
        }

        /// <summary>
        /// This is an error code used to identify why a 
        /// message was not validated. If multiple errors 
        /// occur, only the first value will be indicated. 
        /// The syntaxMULTI error is further detailed in 
        /// the dmsMultiSyntaxError, 
        /// dmsMultiSyntaxErrorPosition and 
        /// dmsMultiOtherErrorDescription objects
        /// </summary>
        [NtcipOid("1.3.6.1.4.1.1206.4.2.3.5.9.0"),
        NtcipAccess(NtcipAccessAttribute.Access.read),
        NtcipMandatory(true)]
        ValidateMessageError dmsValidateMessageError
        {
            get;
        }
    }
}
