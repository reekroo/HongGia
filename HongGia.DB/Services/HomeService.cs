using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

namespace HongGia.DB.Services
{
	public class HomeService
	{
		public static IHomeView GetHome(string lang)
		{
			var home = new HomeView()
			{
				TopNews = NewsService.GetTopNews(PageSizeConstants.TopNews),
				SliderImages = ImageService.GetTopSliderImages(),
				TopPhotos = ImageService.GetImages(PageSearchConstants.TopImage)
			};

			return home;
	}
	}
}
