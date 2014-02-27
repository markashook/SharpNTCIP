using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Property)]
class NtcipAccessAttribute : System.Attribute
{
    public enum Access
    {
        none = 0,
        read = 1,
        write = 2,
    }

    private Access _access;

    public Access NtcipAccess
    {
        get
        {
            return _access;
        }
        set
        {
            _access = value;
        }
    }

    public NtcipAccessAttribute(Access access)
    {
        _access = access;
    }
}
