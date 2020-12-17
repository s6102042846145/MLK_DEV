using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Component.Common
{
    public class Util
    {
        public static List<string> InjectionList = new List<string>() { @"'", ";" };
        public static string NVLString(object obj)
        {
            string value = string.Empty;
            if (obj != null && obj != DBNull.Value)
            {
                value = Convert.ToString(obj).Trim();

                // replace injection
                foreach (string Injection in InjectionList)
                {
                    value = value.Replace(Injection, "");
                }
            }

            return value;
        }

        public static string NVLString(object obj, string defaultValue)
        {
            string value = defaultValue;
            if (obj != null && obj != DBNull.Value)
            {
                value = Convert.ToString(obj).Trim();
            }

            return value;
        }

        public static int NVLInt(object obj)
        {
            int value = 0;
            if (obj != null && obj != DBNull.Value && obj.ToString() != "")
            {
                value = Convert.ToInt32(obj);
            }

            return value;
        }

    }
}
