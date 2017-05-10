using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class PhotoService
    {
        public static IPhotosView GetAllPhoto()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null || context.Photos.Any() == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Photo) == false)
                {
                    return null;
                }

                var catigories = context.Catigories.Where(x => x.Type.ToLower() == PageSearchConstants.Photo).Select(y => y.Name).ToList();
                var photos = context.Photos.Select(photo => new Core.Models.Base.Photo()
                {
                    Id = photo.Id,
                    Name = photo.Name,
                    Path = photo.Path,
					Date = photo.Date.Value,
					UpdateDate = photo.UpdateDate,

                    Categories = photo.Catigories.Select(x => x.Name)
                }).ToList();

                var allPhoto = new PhotosView()
                {
                    Categories = catigories,
                    AllPhoto = photos
                };

                return allPhoto;
            }
        }

        public static IPhotoView GetPhoto(int photoId)
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

                return new PhotoView()
                {
                    Name = photo.Name,
                    Path = photo.Path,
                    Id = photo.Id,
	                Date = photo.Date.Value,
	                UpdateDate = photo.UpdateDate,
					Categories = photo.Catigories.Select(x => x.Name)
                };
            }
        }

        public static ICategoryPhotoView GetCategoryPhoto(string category)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Photos == null ||
                    context.Photos.Any(photo => photo.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Photo)) == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Photo) == false)
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
	                    Date = photo.Date.Value,
	                    UpdateDate = photo.UpdateDate,

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

		public static bool AddPhoto(IPhotoView photo)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Photos == null ||
					context.Photos.Count() < 0 ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Photo) == false)
				{
					return false;
				}

				var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(photo.Categories, PageSearchConstants.Photo);

				var save = new Photo()
				{
					Name = photo.Name,
					Path = photo.Path,
					Date = DateTime.Now
				};

				if (selectCatigories != null)
				{
					foreach (var cat in selectCatigories)
					{
						save.Catigories.Add(cat);
						context.Catigories.Attach(cat);
					}
				}

				context.Photos.Add(save);
				context.SaveChanges();

				return true;
			}
		}

		public static bool UpdatePhoto(IPhotoView photo)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Photos == null ||
					context.Photos.Count() < 0 ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Photo) == false)
				{
					return false;
				}

				var selectPhoto = context.Photos.FirstOrDefault(a => a.Id == photo.Id);

				if (selectPhoto == null)
				{
					return false;
				}

				var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(context, photo.Categories, PageSearchConstants.Photo);

				selectPhoto.Catigories.Clear();

				selectPhoto.Name = photo.Name;
				selectPhoto.Path = photo.Path;
				selectPhoto.UpdateDate = DateTime.Now;

				if (selectCatigories != null)
				{
					foreach (var cat in selectCatigories)
					{
						selectPhoto.Catigories.Add(cat);
						context.Catigories.Attach(cat);
					}
				}
				context.Photos.AddOrUpdate(selectPhoto);

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
    }
}
