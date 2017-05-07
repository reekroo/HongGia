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

			return "https://drive.google.com/uc?export=view&id=" + publicFileId;
		}
	}
}
