using System.Collections.Generic;

using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Interfaces.Base
{
    public interface IPhoto : IFile
    {
        int Id { get; set; }
        IEnumerable<string> Categories { get; set; }
    }
}
