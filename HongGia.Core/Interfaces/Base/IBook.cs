namespace HongGia.Core.Interfaces.Base
{
    public interface IBook : IFile
    {
        int Id { get; set; }

        string Header { get; set; }
    }
}
