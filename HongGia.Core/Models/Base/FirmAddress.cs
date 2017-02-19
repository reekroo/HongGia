using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class FirmAddress : IFirmAddress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Zip { get; set; }
    }
}
