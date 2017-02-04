namespace HongGia.Core.Interfaces.Base
{
    public interface ICollapsiblePanel: IText
    {
        string Header { get; set; }
        IImage Image { get; set; }
    }
}
