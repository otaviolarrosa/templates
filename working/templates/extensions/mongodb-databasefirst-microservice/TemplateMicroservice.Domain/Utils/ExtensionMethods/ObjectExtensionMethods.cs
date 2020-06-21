using System.Net;

namespace TemplateMicroservice.Infrastructure.Utils.ExtensionMethods
{
    public static class ObjectExtensionMethods
    {
        public static int ToInt(this object obj)
        {
            return (int)obj;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}