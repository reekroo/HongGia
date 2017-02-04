using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
    public interface IPhoto : IFile
    {
        int Id { get; set; }
        IEnumerable<string> Categories { get; set; }
    }
}
