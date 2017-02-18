﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public static IPhoto GetPhoto(int photoId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Any() == false)
                {
                    return null;
                }

                var photo = context.Photos.FirstOrDefault(p => p.Id == photoId);

                if (photo == null)
                {
                    return null;
                }

                return new Core.Models.Base.Photo()
                {
                    Name = photo.Name,
                    Path = photo.Path,
                    Id = photo.Id,
                    Categories = photo.Catigories.Select(x => x.Name)
                };
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
                
                var selectPhoto = context.Photos.FirstOrDefault(a => a.Id == photoId);

                if (selectPhoto == null)
                {
                    return false;
                }

                context.Photos.Remove(selectPhoto);
                context.SaveChanges();

                return true;
            }
        }

        public static bool UpdateCatigories(int photoId, IEnumerable<string> categories)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Any() == false)
                {
                    return false;
                }

                var selectPhoto = context.Photos.FirstOrDefault(a => a.Id == photoId);

                if (selectPhoto == null)
                {
                    return false;
                }
                
                var selectCatigories = new List<Catigory>();

                foreach (var category in categories)
                {
                    var cat = context.Catigories.FirstOrDefault(c => c.Name == category && c.Type == "photo");

                    if (cat != null)
                    {
                        selectCatigories.Add(cat);
                    }
                }

                selectPhoto.Catigories = selectCatigories;

                context.Photos.AddOrUpdate(selectPhoto);
                context.SaveChanges();

                return true;
            }
        }
    }
}
