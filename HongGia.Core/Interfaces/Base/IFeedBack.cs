using System;

namespace HongGia.Core.Interfaces.Base
{
    public interface IFeedBack
    {
        int Id { get; set; }
        string Text { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        DateTime Date { get; set; }
        string Language { get; set; }
    }
}
