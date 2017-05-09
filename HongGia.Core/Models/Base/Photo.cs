using System;
using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Photo : IPhoto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Id { get; set; }
        public IEnumerable<string> Categories { get; set; }
	    public DateTime Date { get; set; }
	    public DateTime? UpdateDate { get; set; }
    }
}
