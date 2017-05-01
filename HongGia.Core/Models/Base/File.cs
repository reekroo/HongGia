using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class File : IFile
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
        public string Path { get; set; }
    }
}
