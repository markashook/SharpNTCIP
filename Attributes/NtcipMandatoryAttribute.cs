using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Property)]
class NtcipMandatoryAttribute : System.Attribute
{
    private bool _mandatory;

    public bool NtcipMandatory
    {
        get
        {
            return _mandatory;
        }
        set
        {
            _mandatory = value;
        }
    }

    public NtcipMandatoryAttribute(bool mandatory)
    {
        _mandatory = mandatory;
    }
}
