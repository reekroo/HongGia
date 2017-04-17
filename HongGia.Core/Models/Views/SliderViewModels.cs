using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
	public class SliderView : ISliderView
	{
		public IEnumerable<IImage> SliderImages { get; set; }
	}
}