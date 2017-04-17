using System;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class ImageService
	{
		public static ISliderView GetSliderImages()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Images == null || 
					context.Images.Count() < 0 || 
					context.Images.Any(image => image.Type == "slider") == false)
				{
					return null;
				}

				var sliderImages = new SliderView()
				{
					SliderImages = context.Images.Where(image => image.Type == "slider").Select(x => new Core.Models.Base.Image()
					{
						Id = x.Id,
						Alt = x.Name,
						Src = x.Path
					}).ToList()
				};

				return sliderImages;
			}
		}

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

    }
}
