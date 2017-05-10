namespace HongGia.BL.SmallFunctional
{
	public class StringTruncater
	{
		private const int StringLangth = 500;

		public static string Truncate(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}

			if (str.Length <= StringLangth)
			{
				return str;
			}

			int endIndex = str.Substring(0, StringLangth).LastIndexOf(' ');

			if (endIndex <= 0)
			{
				return str;
			}

			return str.Substring(0, endIndex) + "...";
		}
	}
}
