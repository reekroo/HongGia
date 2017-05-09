using System;

namespace HongGia.Core.Interfaces.Base
{
	public interface INews
	{
		int Id { get; set; }
		string Text { get; set; }
		string Header { get; set; }
		DateTime Date { get; set; }
		DateTime? UpdateDate { get; set; }
		IImage Image { get; set; }
		string Language { get; set; }
		string ImagePAth { get; set; }
	}
}
