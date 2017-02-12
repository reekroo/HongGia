using System;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class PhotoService
    {
        public static IAllPhotoView GetAllPhoto()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Any() == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "photo") == false)
                {
                    return null;
                }

                var catigories = context.Catigories.Where(x => x.Type.ToLower() == "photo").Select(y => y.Name).ToList();
                var photos = context.Photos.Select(photo => new Core.Models.Base.Photo()
                {
                    Id = photo.Id,
                    Name = photo.Name,
                    Path = photo.Path,
                    Categories = photo.Catigories.Select(x => x.Name)
                }).ToList();

                var allPhoto = new AllPhotoView()
                {
                    Categories = catigories,
                    AllPhoto = photos
                };

                return allPhoto;
            }
        }

        public static ICategoryPhotoView GetCategoryPhoto(string category)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null ||
                    context.Photos.Any(photo => photo.Catigories.Any(x => x.Type.ToLower() == "photo")) == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "photo") == false)
                {
                    return null;
                }

                var photos = (
                    from photo
                    in context.Photos
                    where photo.Catigories.Where(x => x.Name.Contains(category)).ToList().Count > 0
                    select new Core.Models.Base.Photo()
                    {
                        Id = photo.Id,
                        Name = photo.Name,
                        Path = photo.Path,
                        Categories = photo.Catigories.Select(x => x.Name)
                    }).ToList();

                var categoryPhotos = new CategoryPhotoView()
                {
                    Category = category,
                    CategoryPhoto = photos
                };

                return categoryPhotos;
            }
        }

        public static bool AddPhoto(IPhoto photo)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Count() < 0 ||
                    context.Catigories.Any(x => x.Type.ToLower() == "photo") == false)
                {
                    return false;
                }

                var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(photo.Categories, "photo");

                var save = new Photo()
                {
                    Name = photo.Name,
                    Path = photo.Path,
                    Date = DateTime.Now,
                    Catigories = selectCatigories
                };

                context.Photos.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemovePhoto(int photoId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Any() == false)
                {
                    return false;
                }
                
                var selectNews = context.News.FirstOrDefault(a => a.Id == photoId);

                if (selectNews == null)
                {
                    return false;
                }

                context.News.Remove(selectNews);
                context.SaveChanges();

                return true;
            }
        }

        //AddPhotoToCatigory
        //RemovePhotoFromCatigory
    }
}