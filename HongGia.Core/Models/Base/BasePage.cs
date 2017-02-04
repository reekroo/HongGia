using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class BasePage : IBasePage
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public IEnumerable<ITopic> Topics { get; set; }
        public IEnumerable<IImage> Images { get; set; }
        public IEnumerable<IFile> Files { get; set; }
    }
}
