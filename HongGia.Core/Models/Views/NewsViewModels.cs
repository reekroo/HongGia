using System;
using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
	public class AllNewsView : IAllNewsView
	{
		public IEnumerable<INews> AllNews { get; set; }
	}

	public class NewsView : INewsView
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string Header { get; set; }
		public DateTime Date { get; set; }
		public DateTime? UpdateDate { get; set; }
		public IImage Image { get; set; }
		public string Language { get; set; }
		public string ImagePAth { get; set; }
	}
}