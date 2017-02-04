namespace HongGia.Core.Interfaces.Base
{
    public interface ITopic : ICollapsiblePanel
    {
        int Id { get; set; }
        string Type { get; set; }
        int Position { get; set; }
    }
}
