using System;
using System.Data.Entity.Migrations;
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
				if (context.Pages.Any() == false ||
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

		public static IBasePageView GetBasePageContent(string name, string lang)
		{
			if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(lang))
			{
				return null;
			}
			
			using (var context = new EntitiesDB())
			{
				var selectPage = context.Pages.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));

				var pageContent = selectPage?.PageContents.FirstOrDefault(x => x.Language.Name.ToLower().Contains(lang));

				if (pageContent == null)
				{
					return null;
				}

				return new BasePageView()
				{
					Id = pageContent.Id,
					Header = pageContent.Header,

					Images = pageContent.Images?.Select(x => new HongGia.Core.Models.Base.Image()
					{
						Id = x.Id,
						Alt = x.Name,
						Src = x.Path
					}).ToList(),
					
					Files = pageContent.Files?.Select(x => new HongGia.Core.Models.Base.File()
					{
						Id = x.Id,
						Name = x.Name,
						Path = x.Path
					}).ToList(),

					Topics = pageContent.Topics?.Select(x => new HongGia.Core.Models.Base.Topic()
					{
						Id = x.Id,
						Header = x.Header,
						Position = x.Position ?? 0,
						Type = x.TopicType?.Name,
						Date = x.Date.Value,
						UpdateDate = x.UpdateDate,

						HtmlText = x.HTMLText,
						Image = null
					}).ToList()
				};
			}
		}

		public static bool AddBasePageContent(string name, string lang)
		{
			if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(lang))
			{
				return false;
			}

			using (var context = new EntitiesDB())
			{
				var selectPage = context.Pages.FirstOrDefault(x => x.Name.ToLower().Contains(name));

				if (selectPage == null ||
				    context.Languages.Any(x => x.Name.ToLower().Contains(lang)) == false)
				{
					return false;
				}

				var save = new PageContent()
				{
					Date = DateTime.Now,
					Header = selectPage.Name,
					Page = selectPage,
					Language = context.Languages.FirstOrDefault(x => x.Name.ToLower().Contains(lang))
				};

				context.PageContents.Add(save);
				context.SaveChanges();
			}

			return true;
		}

		public static bool UpdateBasePageContentName(int basepageContentId, string name, string lang)
		{
			if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(lang))
			{
				return false;
			}

			using (var context = new EntitiesDB())
			{
				if (context.Languages.Any(x => x.Name.ToLower().Contains(lang)) == false ||
					context.PageContents.Any() == false)
				{
					return false;
				}

				var selectPageContent = context.PageContents.FirstOrDefault(x => x.Id == basepageContentId && x.Language.Name.ToLower().Contains(lang));

				if (selectPageContent == null)
				{
					return false;
				}

				selectPageContent.Header = name;

				context.PageContents.AddOrUpdate(selectPageContent);
				context.SaveChanges();
			}

			return true;
		}

		public static bool RemoveBasePageContent(int basePageContentId)
		{
			using (var context = new EntitiesDB())
			{
				var select = context.PageContents.FirstOrDefault(x => x.Id == basePageContentId);

				if (select == null)
				{
					return false;
				}

				context.PageContents.Remove(select);
				context.SaveChanges();

				return true;
			}
		}
	}
}
