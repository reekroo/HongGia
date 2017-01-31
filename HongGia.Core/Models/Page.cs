using System.Collections.Generic;

using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models
{
    public class Page
    {
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<FileParameters> Files { get; set; }
        public IEnumerable<ImageParameters> Images { get; set; }
    }
}
