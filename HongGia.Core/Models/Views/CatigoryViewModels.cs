using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
	public class CatigoriesViewModels : ICatigoriesView
	{
		public IEnumerable<ICatigory> Categories { get; set; }
	}
}