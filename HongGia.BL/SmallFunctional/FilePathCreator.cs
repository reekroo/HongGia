namespace HongGia.BL.SmallFunctional
{
	public class FilePathCreator
	{
		public static string GetGooglePath(string publicFileId)
		{
			if (string.IsNullOrEmpty(publicFileId))
			{
				return string.Empty;
			}

			return "https://drive.google.com/uc?export=view&id=" + GetId(publicFileId, '=');
		}

		public static string GetYouTubePath(string publicFileId)
		{
			if (string.IsNullOrEmpty(publicFileId))
			{
				return string.Empty;
			}

			return "https://www.youtube.com/embed/" + GetId(publicFileId, '=');
		}

		public static string GetYouTubeImagePath(string publicFileId)
		{
			if (string.IsNullOrEmpty(publicFileId))
			{
				return string.Empty;
			}

			return "//img.youtube.com/vi/" + GetId(publicFileId, '/') + "/0.jpg";
		}

		private static string GetId(string str, char sumble)
		{
			var index = str.LastIndexOf(sumble);

			if (index == 0)
			{
				return str;
			}
			
			return str.Remove(0, index + 1);
		}
	}
}
