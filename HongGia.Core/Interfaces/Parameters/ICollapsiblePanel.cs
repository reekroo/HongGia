﻿namespace HongGia.Core.Interfaces.Parameters
{
    public interface ICollapsiblePanel: IText
    {
        string Header { get; set; }
        IImage Image { get; set; }
    }
}
