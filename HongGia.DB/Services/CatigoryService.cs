using System.Collections.Generic;
using System.Linq;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;
using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class CatigoryService
    {
	    public static ICollection<Catigory> GetCatigoriesByNamesAndType(EntitiesDB context, IEnumerable<string> names, string type)
	    {
			if (context.Catigories.Any(c => c.Type == type) == false ||
					   names == null ||
					   names.Any() == false ||
					   string.IsNullOrEmpty(type))
			{
				return null;
			}

			var selectCatigories = new List<Catigory>();
			foreach (var catigory in names)
			{
				var selectCatigory = context.Catigories.FirstOrDefault(c => c.Name.ToLower().Contains(catigory) && c.Type.ToLower() == type);

				if (selectCatigory != null)
				{
					selectCatigories.Add(selectCatigory);
				}
			}

			if (selectCatigories.Count == 0)
			{
				return null;
			}

			return selectCatigories;
		}

	    public static ICollection<Catigory> GetCatigoriesByNamesAndType(IEnumerable<string> names, string type)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Catigories.Any(c => c.Type == type) == false ||
					names == null ||
					names.Any() == false ||
					string.IsNullOrEmpty(type))
                {
                    return null;
                }

                var selectCatigories = new List<Catigory>();
                foreach (var catigory in names)
                {
                    var selectCatigory = context.Catigories.FirstOrDefault(c => c.Name.ToLower().Contains(catigory) && c.Type.ToLower() == type);

                    if (selectCatigory != null)
                    {
                        selectCatigories.Add(selectCatigory);
                    }
                }

                if (selectCatigories.Count == 0)
                {
                    return null;
                }

                return selectCatigories;
            }
        }

        public static ICollection<Catigory> GetCatigoriesByType(string type)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Catigories == null)
                {
                    return null;
                }

                var result = context.Catigories.Where(c => c.Type == type).ToList();
                
                if (result.Any() == false)
                {
                    return null;
                }

                return result;
            }
        }

        public static IEnumerable<string> GetCatigoriesListStringByType(string type)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Catigories == null)
                {
                    return null;
                }

                var result = context.Catigories.Where(c => c.Type == type).ToList();

                if (result.Any() == false)
                {
                    return null;
                }

                return result.Select(r => r.Name).ToList();
            }
        }

		public static ICatigoriesView GetCatigories()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Catigories.Any() == false)
				{
					return null;
				}

				var result = new CatigoriesView();

				result.Categories = context.Catigories.Select(c => new Core.Models.Base.Catigory()
				{
					Name = c.Name,
					Id = c.Id,
					Type = c.Type
				}).ToList();

				return result;
			}
		}

		public static bool AddCatigory(Core.Models.Base.Catigory catigory)
		{
			using (var context = new EntitiesDB())
			{
				if (catigory == null ||
					string.IsNullOrEmpty(catigory.Name) ||
					string.IsNullOrEmpty(catigory.Type))
				{
					return false;
				}

				var save = new Catigory()
				{
					Name = catigory.Name,
					Type = catigory.Type
				};

				context.Catigories.Add(save);
				context.SaveChanges();

				return true;
			}
		}

		public static bool RemoveCatigory(int catigoryId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Catigories.Any() == false)
				{
					return false;
				}

				var selectCatigory = context.Catigories.FirstOrDefault(x => x.Id == catigoryId);

				if (selectCatigory == null)
				{
					return false;
				}

				context.Catigories.Remove(selectCatigory);
				context.SaveChanges();

				return true;
			}
		}
	}
}
