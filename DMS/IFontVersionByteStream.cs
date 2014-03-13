using System;
using System.Collections.Generic;
using System.Text;

namespace SharpNTCIP.DMS
{
    public interface IFontVersionByteStream
    {
        IFontInformation fontInformation
        {
            get;
        }

        CharacterInfoList characterInfoList
        {
            get;
        }
    }
}
