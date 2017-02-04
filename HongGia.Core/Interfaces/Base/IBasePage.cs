using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
    public interface IBasePage
    {
        int Id { get; set; }
        string Header { get; set; }
        IEnumerable<ITopic> Topics { get; set; }
        IEnumerable<IImage> Images { get; set; }
        IEnumerable<IFile> Files { get; set; }
    }
}
