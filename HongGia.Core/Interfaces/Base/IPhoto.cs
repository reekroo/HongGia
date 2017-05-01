using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
	public interface IPhoto : IFile
	{
		IEnumerable<string> Categories { get; set; }
	}
}
