﻿using System.Collections.Generic;

using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models
{
    public class Photo : FileParameters
    {
        public int Id { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
