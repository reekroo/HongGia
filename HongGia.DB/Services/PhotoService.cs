using System;
using System.Collections.Generic;
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
                    context.Photos.Any(photo => photo.Catigories.Any(x => x.Type == "photo")) == false ||
                    context.Catigories.Any(x => x.Type.ToLower()== "photo") == false)
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
    }
}
