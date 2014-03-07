using SharpNTCIP.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNTCIP
{
    public class Helper
    {
        public static string GetOid(Type implementedInterface, string implementedProperty)
        {
            string oid = string.Empty;
            var interfaceMethod = implementedInterface.GetProperty(implementedProperty);
            if (interfaceMethod != null)
            {
                NtcipOidAttribute attributeOid = interfaceMethod.GetCustomAttributes(
                    typeof(NtcipOidAttribute), true).FirstOrDefault() as NtcipOidAttribute;
                if (attributeOid != null)
                {
                    oid = attributeOid.NtcipOid;
                }
            }
            return oid;
        }

        public static T EnumParse<T>(object value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), Enum.GetName(typeof(T), value));
            } catch
            {
                throw new InvalidCastException("Returned value does not match known NTCIP values. Perhaps this device implements a newer version of the NTCIP standard");
            }
        }
    }
}
