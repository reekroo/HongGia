using HongGia.Core.Interfaces.Base;

using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Models.Base
{
    public class Video : IVideo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
        public IImage Screen { get; set; }
    }
}
