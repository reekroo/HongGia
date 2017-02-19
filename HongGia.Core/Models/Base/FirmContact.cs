using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class FirmContact : IFirmContact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
    }
}
