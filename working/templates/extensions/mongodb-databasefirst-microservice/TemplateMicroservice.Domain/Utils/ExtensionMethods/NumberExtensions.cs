namespace TemplateMicroservice.Infrastructure.Utils.ExtensionMethods
{
    public static class NumberExtensions
    {
        public static long ToLong(this int number)
        {
            return (long)number;
        }

        public static long ToLong(this object number)
        {
            return (long)number;
        }
    }
}