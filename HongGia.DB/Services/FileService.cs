using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class FileService
	{
		public static bool Add(IFile file)
		{
			using (var context = new EntitiesDB())
			{
				var save = new File()
				{
					Name = file.Name,
					Path = file.Path,
					Date = DateTime.Now
				};

				context.Files.Add(save);
				context.SaveChanges();

				return true;
			}
		}

		public static bool Add(IFile file, int pageContentId)
		{
			if (file == null)
			{
				return false;
			}
			
			using (var context = new EntitiesDB())
			{
				var pageContent = context.PageContents.FirstOrDefault(x => x.Id == pageContentId);

				if (pageContent == null)
				{
					return false;
				}

				pageContent.Files.Add(new File()
				{
					Date = DateTime.Now,
					Name = file.Name,
					Path = file.Path,
				});

				context.PageContents.AddOrUpdate(pageContent);
				context.SaveChanges();

				return true;
			}
		}

		public static bool Remove(int fileId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Files.Any() == false)
				{
					return false;
				}

				var selectFile = context.Files.FirstOrDefault(f => f.Id == fileId);

				if (selectFile == null)
				{
					return false;
				}

				context.Files.Remove(selectFile);
				context.SaveChanges();

				return true;
			}
		}
    }
}
