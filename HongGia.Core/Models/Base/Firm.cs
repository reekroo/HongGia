using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
    public class Firm : IFirm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IFirmContact> Contacts { get; set; }
        public IEnumerable<IFirmAddress> Addresses { get; set; }
    }
}
