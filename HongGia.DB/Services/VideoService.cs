using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class VideoService
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

        public static bool AddVideo(IVideo video)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Videos == null || context.Videos.Count() < 0)
                {
                    return false;
                }

                if (video.Screen != null)
                {
                    ImageService.AddImage(video.Screen);
                }

                //var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(video., "article");

                var save = new Video()
                {
                    Name = video.Name,
                    Path = video.Path,

                    Date = DateTime.Now,
                    Image = context.Images.Last(),

                    Catigories = null
                };

                context.Videos.Add(save);
                context.SaveChanges();

                return true;
            }
        }
        
        //maybe remove it
        public static bool UpdateVideo(IVideo video)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Videos == null || context.Videos.Count() < 0)
                {
                    return false;
                }

                var selectVideo = context.Videos.FirstOrDefault(a => a.Id == video.Id);

                if (selectVideo == null)
                {
                    return false;
                }
                
                if (video.Screen != null)
                {
                    ImageService.AddImage(video.Screen);
                    selectVideo.Image = context.Images.Last();
                }
                else
                {
                    selectVideo.Image = null;
                }

                selectVideo.Name = video.Name;
                selectVideo.Path = video.Path;
                selectVideo.Date = DateTime.Now;
                selectVideo.Catigories = null;

                context.Videos.AddOrUpdate(selectVideo);
                context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveVideo(int videoId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Videos.Any() == false)
                {
                    return false;
                }

                var selectVideo = context.Videos.FirstOrDefault(v => v.Id == videoId);

                if (selectVideo == null)
                {
                    return false;
                }

                if (selectVideo.Image != null)
                {
                    ImageService.RemoveImage(selectVideo.Image.Id);
                }

                context.Videos.Remove(selectVideo);
                context.SaveChanges();

                return true;
            }
        }
    }
}
