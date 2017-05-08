namespace HongGia.BL.SmallFunctional
{
    public class StringTruncater
    {
        private const int stringLangth = 500;

        public static string Truncate(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (str.Length <= stringLangth)
            {
                return str;
            }

            int endIndex = str.Substring(0, stringLangth).LastIndexOf(' ');

            return str.Substring(0, endIndex) + "...";
        }
    }
}
