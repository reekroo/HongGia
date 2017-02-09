using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;

namespace HongGia.Core.Models.Views
{
    public class BasePageView : IBasePageView
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public IEnumerable<ITopic> Topics { get; set; }
        public IEnumerable<IImage> Images { get; set; }
        public IEnumerable<IFile> Files { get; set; }
    }
}
