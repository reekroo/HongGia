using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Catigory : ICatigory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
