using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
