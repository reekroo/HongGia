using HongGia.Core.Parameters.Base;

namespace HongGia.Core.Models
{
    public class Book : FileParameters
    {
        public int Id { get; set; }

        public string Header { get; set; }
    }
}
