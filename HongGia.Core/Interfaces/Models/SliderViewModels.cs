using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
	public interface ISliderView
	{
		IEnumerable<IImage> SliderImages { get; set; }
	}
}