using System;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
	public class News : INews
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
