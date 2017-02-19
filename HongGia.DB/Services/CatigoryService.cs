using System.Collections.Generic;
using System.Linq;
using HongGia.Core.Interfaces.Base;
using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class CatigoryService
    {
        public static ICollection<Catigory> GetCatigoriesByNamesAndType(IEnumerable<string> names, string type)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Catigories.Any(c => c.Type == type) == false)
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

        public static IEnumerable<Catigory> GetCatigories()
        {
            using (var context = new EntitiesDB())
            {
                var result = context.Catigories?.Select(c => new Catigory()
                {
                    Name = c.Name,
                    Id = c.Id,
                    Type = c.Type
                });
                
                return result;
            }
        }
    }
}
