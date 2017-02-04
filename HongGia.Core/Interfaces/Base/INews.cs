using System;

using HongGia.Core.Interfaces.Parameters;

namespace HongGia.Core.Interfaces.Base
{
    public interface INews
    {
        int Id { get; set; }
        string Text { get; set; }
        string Header { get; set; }
        DateTime Date { get; set; }
        IImage Image { get; set; }
        string Language { get; set; }
    }
}
