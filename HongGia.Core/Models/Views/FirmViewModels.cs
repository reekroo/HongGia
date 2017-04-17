using System.Collections.Generic;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Base;

namespace HongGia.Core.Models.Views
{
	public class Firmsview : IFirmsview
	{
		public IEnumerable<IFirm> Firms { get; set; }
	}

	public class FirmView : IFirmView
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<FirmContact> Contacts { get; set; }
		public IEnumerable<FirmAddress> Addresses { get; set; }
	}
}