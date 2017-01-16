using System.Collections.Generic;

namespace HongGia.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
