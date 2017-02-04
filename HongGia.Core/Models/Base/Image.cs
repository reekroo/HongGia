using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Image : IImage
    {
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
