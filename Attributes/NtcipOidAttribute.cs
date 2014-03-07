using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Property | AttributeTargets.Class)]
    public class NtcipOidAttribute : System.Attribute
    {
        private string _oid;

        public string NtcipOid
        {
            get
            {
                return _oid;
            }
            set
            {
                _oid = value;
            }
        }

        public NtcipOidAttribute(string oid)
        {
            _oid = oid;
        }
    }
}