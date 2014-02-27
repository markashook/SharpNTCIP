using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Property)]
class NtcipOidAttribute : System.Attribute
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
