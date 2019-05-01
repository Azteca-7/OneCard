using System;
using System.ComponentModel;
using System.Reflection;

namespace Cards.Webservice
{
    public class Constants
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
             (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute),
             false);

            if (attributes != null &&
             attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public enum eMethod
        {
            [Description("POST")]
            POST,
            [Description("GET")]
            GET,
            [Description("PUT")]
            PUT,
        }

        public enum eUrlApi
        {
            [Description("/api/Cards/Balance")]
            Login,
            [Description("/api/Cards/Balance")]
            Balance,
            
        }

        public enum eContentType
        {
            [Description("application/x-www-form-urlencoded")]
            UrlEncoded,
            [Description("application/json; charset=utf-8")]
            Json
        }
    }


}
