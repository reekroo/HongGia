using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Interfaces.Models
{
    public interface IAllPhotoView
    {
        IEnumerable<string> Categories { get; set; }

        IEnumerable<IPhoto> AllPhoto { get; set; }
    }


    public interface ICategoryPhotoView
    {
        string Category { get; set; }

        IEnumerable<IPhoto> CategoryPhoto { get; set; }
    }
}