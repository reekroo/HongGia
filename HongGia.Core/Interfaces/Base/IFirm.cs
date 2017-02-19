using System.Collections.Generic;

namespace HongGia.Core.Interfaces.Base
{
    public interface IFirm
    {
        int Id { get; set; }

        string Name { get; set; }
        
        IEnumerable<IFirmContact> Contacts { get; set; }
        
        IEnumerable<IFirmAddress> Addresses { get; set; }
    }
}
