using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Parameters.Base
{
    public class ImageParameters : IImage
    {
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
