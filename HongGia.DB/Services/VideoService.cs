﻿using System;
using System.Data.Entity.Migrations;
using System.Linq;

using HongGia.Core.Constants;
using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

using Video = HongGia.DB.Models.Video;

namespace HongGia.DB.Services
{
	public class VideoService
	{
		public static IVideosView GetAllVideo()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Videos == null ||
					context.Videos.Any() == false ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Video) == false)
				{
					return null;
				}

				var catigories = context.Catigories.Where(x => x.Type.ToLower() == PageSearchConstants.Video).Select(y => y.Name).ToList();

				var videos = context.Videos.Select(video => new Core.Models.Base.Video()
				{
					Id = video.Id,
					Name = video.Name,
					Path = video.Path,
					Date = video.Date.Value,
					UpdateDate = video.UpdateDate,

					Screen = new HongGia.Core.Models.Base.Image()
					{
						Src = video.Image.Path,
						Alt = video.Image.Name
					},
					Categories = video.Catigories.Select(x => x.Name)
				}).ToList();

				var allvideos = new VideosView()
				{
					AllVideo = videos,
					Categories = catigories
				};

				return allvideos;
			}
		}

		public static IVideo GetVideo(int videoId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Videos == null ||
					context.Videos.Any() == false ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Video) == false)
				{
					return null;
				}
				
				var video = context.Videos.FirstOrDefault(p => p.Id == videoId);

				if (video == null)
				{
					return null;
				}

				return new VideoView()
				{
					Id = video.Id,
					Name = video.Name,
					Path = video.Path,
					Date = video.Date.Value,
					UpdateDate = video.UpdateDate,

					Screen = new HongGia.Core.Models.Base.Image()
					{
						Src = video.Image.Path,
						Alt = video.Image.Name
					},
					Categories = video.Catigories.Select(x => x.Name)
				};
			}
		}

		public static bool AddVideo(IVideo video)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Videos == null || 
					context.Videos.Count() < 0 ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Video) == false)
				{
					return false;
				}

				var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(video.Categories, PageSearchConstants.Video);

				var save = new Video()
				{
					Name = video.Name,
					Path = video.Path,
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
				context.Videos.Add(save);

				context.SaveChanges();

				return true;
			}
		}

		public static bool UpdateVideo(IVideo video)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Videos == null ||
					context.Videos.Count() < 0 ||
					context.Catigories.Any(x => x.Type.ToLower() == PageSearchConstants.Video) == false)
				{
					return false;
				}

				var selectVideo = context.Videos.FirstOrDefault(a => a.Id == video.Id);

				if (selectVideo == null)
				{
					return false;
				}

				var selectCatigories = CatigoryService.GetCatigoriesByNamesAndType(context, video.Categories, PageSearchConstants.Video);

				selectVideo.Catigories.Clear();

				selectVideo.Name = video.Name;
				selectVideo.Path = video.Path;
				selectVideo.UpdateDate = DateTime.Now;

				if (selectCatigories != null)
				{
					foreach (var cat in selectCatigories)
					{
						selectVideo.Catigories.Add(cat);
						context.Catigories.Attach(cat);
					}
				}

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

				context.Videos.Remove(selectVideo);
				context.SaveChanges();

				return true;
			}
		}
	}
}
