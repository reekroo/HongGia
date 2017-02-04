using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
namespace HongGia.Core.Interfaces.Models
{
    public interface IAllNewsView
    {
        IEnumerable<INews> AllNews { get; set; }
    }

    public interface INewsView : INews
    {
    }
}