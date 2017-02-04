using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Interfaces.Base
{
    public interface IVideo : IFile
    {
        int Id { get; set; }

        IImage Screen { get; set; }
    }
}
