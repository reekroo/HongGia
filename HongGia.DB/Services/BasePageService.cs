using System.Linq;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class BasePageService
	{
		public static IBasePageInformationView GetInformation()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Pages.Any() == false &&
					context.Languages.Any() == false)
				{
					return null;
				}

				var result = new BasePageInformationView()
				{
					PageLangs = context.Languages.Select(x => x.Name).ToList(),
					PageNames = context.Pages.Select(x => x.Name).ToList()
				};

				return result;;
			}
		}

		public static bool AddBasePageName(string name)
		{
			if (string.IsNullOrEmpty(name) == true)
			{
				return false;
			}

			using (var context = new EntitiesDB())
			{
				if (context.Pages.Any(x => x.Name == name) == true)
				{
					return false;
				}

				context.Pages.Add(new Page()
				{
					Name = name
				});

				context.SaveChanges();

				return true;
			}
		}

		public static bool AddLang(string name)
		{
			if (string.IsNullOrEmpty(name) == true)
			{
				return false;
			}

			using (var context = new EntitiesDB())
			{
				if (context.Languages.Any(x => x.Name == name) == true)
				{
					return false;
				}

				context.Languages.Add(new Language()
				{
					Name = name
				});

				context.SaveChanges();

				return true;
			}
		}
	}
}
