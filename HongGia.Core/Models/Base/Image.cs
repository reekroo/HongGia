using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Image : IImage
    {
	    public int Id { get; set; }
	    public string Src { get; set; }
        public string Alt { get; set; }
    }
}
