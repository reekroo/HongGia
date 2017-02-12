using HongGia.Core.Interfaces.Models;

namespace HongGia.DB.Services
{
    public class MediaService
    {
        public static IVideoView GetAllVideo()
        {
            return VideoService.GetAllVideo();
         }

        public static IBooksView GetAllBookFiles()
        {
            return BookService.GetAllBookFiles();
        }
    }
}
