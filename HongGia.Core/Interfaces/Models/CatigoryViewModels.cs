using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface ICatigoriesView
	{
        IEnumerable<ICatigory> Categories { get; set; }
    }
}