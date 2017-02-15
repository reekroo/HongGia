using System;
using System.Linq;

using HongGia.Core.Interfaces.Base;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class ImageService
    {
        public static bool AddImage(IImage image)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Images == null || context.Images.Count() < 0)
                {
                    return false;
                }

                var save = new Image()
                {
                    Name = image.Alt,
                    Path = image.Src,
                    Date = DateTime.Now
                };

                context.Images.Add(save);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveImage(int imageId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Images == null || context.Images.Count() < 0)
                {
                    return false;
                }

                var selectImage = context.Images.FirstOrDefault(i => i.Id == imageId);

                if (selectImage == null)
                {
                    return false;
                }

                context.Images.Remove(selectImage);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveImage(IImage image)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Images == null || context.Images.Count() < 0)
                {
                    return false;
                }

                var selectImage = context.Images.FirstOrDefault(i => i.Name == image.Alt && i.Path == image.Src);

                if (selectImage == null)
                {
                    return false;
                }

                context.Images.Remove(selectImage);
                context.SaveChanges();

                return true;
            }
        }

        //add remove images
    }
}
