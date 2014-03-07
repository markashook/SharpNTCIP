using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NtcipMandatoryAttribute : System.Attribute
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
}