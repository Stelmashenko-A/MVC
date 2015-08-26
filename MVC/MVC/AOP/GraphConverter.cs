using System;
using System.Text;
using System.Web.Helpers;

namespace MVC.AOP
{
    public class JsonConverter : IConverter
    {
        public string Convert(object item)
        {
            var sb = new StringBuilder();

            try
            {
                sb.Append(Json.Encode(item));
            }
            catch (Exception)
            {
                sb.Append("Unserializeble object");
            }

            return sb.ToString();

        }
    }
}