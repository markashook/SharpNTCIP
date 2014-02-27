using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.TSS
{
    public interface ITSSControl
    {
        UInt16 maxOutputNumber
        {
            get;
        }

        List<OutputConfigurationEntry> outputConfigurationEntry
        {
            get;
        }

        UInt16 maxOutputGroups
        {
            get;
        }

        List<OutputGroupEntry> outputGroupTable
        {
            get;
        }
    }
}
