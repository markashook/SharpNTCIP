using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    ///TODO: Label with NTCIP OIDs

    /// <summary>
    /// Contains the currently displayed value of a specified Field
    /// </summary>
    public interface IStatMultiFieldEntry
    {
        /// <summary>
        /// The index number into this table indicating the sequential 
        /// order of the field within the MULTI-string (1-255)
        /// </summary>
        byte statMultiFieldIndex
        {
            get;
        }

        /// <summary>
        /// Indicates the ID of the value of the 
        /// statMultiCurrrentFieldValue-object. The field codes are 
        /// indicated under the ‘Field’-tag in MULTI
        /// </summary>
        byte statMultiFieldCode
        {
            get;
        }

        /// <summary>
        /// Indicates the currently displayed text of the MULTI-message 
        /// for the corresponding Field
        /// </summary>
        byte[] statMultiCurrentFieldValue
        {
            get;
        }
    }
}
