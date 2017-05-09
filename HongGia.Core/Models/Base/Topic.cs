using System;
using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
	public class Topic : ITopic
	{
		public string HtmlText { get; set; }
		public string Header { get; set; }
		public IImage Image { get; set; }
		public int Id { get; set; }
		public string Type { get; set; }
		public int Position { get; set; }
		public DateTime Date { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
