using System.Collections.Generic;
using System.Linq;

using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class MediaService
    {
        public static IVideoView GetAllVideo()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Videos == null || context.Videos.Any() == false)
                {
                    return null;
                }

                var videos = context.Videos.Select(video => new Core.Models.Base.Video()
                {
                    Id = video.Id,
                    Name = video.Name,
                    Path = video.Path,
                    Screen = new HongGia.Core.Models.Base.Image()
                    {
                        Src = video.Image.Path,
                        Alt = video.Image.Name
                    }
                }).ToList();

                var allvideos = new VideoView()
                {
                    AllVideo = videos
                };

                return allvideos;
            }
        }

        public static IBooksView GetAllBookFiles()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files == null || context.Files.Any() == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "book") == false)
                {
                    return null;
                }

                var books = new List<Core.Models.Base.Book>();

                foreach (var book in context.Files)
                {
                    if (book.Catigories.Any(x => x.Type == "book"))
                    {
                        books.Add(new Core.Models.Base.Book()
                        {
                            Id = book.Id,
                            Header = book.Name,
                            Name = book.Name,
                            Path = book.Path
                        });
                    }
                }

                var allBookFiles = new BooksView()
                {
                    AllBooks = books
                };

                return allBookFiles;
            }
        }
    }
}
