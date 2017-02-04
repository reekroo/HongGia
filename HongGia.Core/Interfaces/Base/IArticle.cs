using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
    public interface IArticle : IText
    {
        int Id { get; set; }

        string Header { get; set; }
        
        IEnumerable<string> Categories { get; set; }
    }
}
