namespace Biblioteca.ExtensionMethods
{
    public static class StringExtension
    {
        public static string AddSlashes(this string str)
        {
            return str.Replace("'", @"\'");
        }
    }
}
