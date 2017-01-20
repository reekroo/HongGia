using HongGia.Core.Parameters;

namespace HongGia.Core.Models
{
    public class Video : FileParameters
    {
        public int Id { get; set; }

        public ImageParameters Screen { get; set; }
    }
}
