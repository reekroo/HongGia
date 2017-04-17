using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Models.Base;

namespace HongGia.Core.Interfaces.Models
{
	public interface IFirmsview
	{
		IEnumerable<IFirm> Firms { get; set; }
	}

	public interface IFirmView
	{
		int Id { get; set; }
		string Name { get; set; }
		IEnumerable<FirmContact> Contacts { get; set; }
		IEnumerable<FirmAddress> Addresses { get; set; }
	}
}