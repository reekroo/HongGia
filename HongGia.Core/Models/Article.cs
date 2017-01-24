using System.Collections.Generic;

using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models
{
    public class Article : TextParameters
    {
        public int Id { get; set; }
        
        public IEnumerable<string> Categories { get; set; }
    }
}
