using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
	public interface IVideo : IFile
	{
		IImage Screen { get; set; }
		IEnumerable<string> Categories { get; set; }
	}
}
