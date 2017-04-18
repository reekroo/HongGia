using System.Collections.Generic;
using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
	public interface IBasePageView : IBasePage
	{
	}

	public interface IBasePageInformationView
	{
		IEnumerable<string> PageLangs { get; set; }

		IEnumerable<string> PageNames { get; set; }

	}
}