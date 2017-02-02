using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models.Base
{
    public class Video : FileParameters
    {
        public int Id { get; set; }

        public ImageParameters Screen { get; set; }
    }
}
