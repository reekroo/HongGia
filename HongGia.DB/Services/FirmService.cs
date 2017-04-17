using System;
using System.Linq;

using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;
using HongGia.DB.Models;

namespace HongGia.DB.Services
{
	public class FirmService
	{
		public static IFirmsview GetFirms()
		{
			using (var context = new EntitiesDB())
			{
				if (context.Firms.Any() == false)
				{
					return null;
				}

				var result = new Firmsview
				{
					Firms = context.Firms.Select(f => new HongGia.Core.Models.Base.Firm()
					{
						Name = f.Name,
						Id = f.Id,

						Addresses = f.FirmAddresses.Select(a => new HongGia.Core.Models.Base.FirmAddress()
						{
							Id = a.Id,
							City = a.City,
							Country = a.Country,
							Home = a.Home,
							Street = a.Street,
							Zip = a.Zip
						}).ToList(),

						Contacts = f.FirmContacts.Select(a => new HongGia.Core.Models.Base.FirmContact()
						{
							Id = a.Id,
							Name = a.Name,
							Mail = a.Mail,
							Phone = a.Phone
						}).ToList()
					}).ToList()
				};

				return result;
			}
		}

		public static bool AddFirm(IFirmView firm)
		{
			if (firm == null || 
				string.IsNullOrEmpty(firm.Name))
			{
				return false;
			}

			using (var context = new EntitiesDB())
			{
				var save = new Firm()
				{
					Name = firm.Name,
					Date = DateTime.Now,

					FirmAddresses = firm.Addresses.Select(x => new FirmAddress()
					{
						City = x.City,
						Country = x.Country,
						Street = x.Street,
						Home = x.Home,
						Zip = x.Zip
					}).ToList(),

					FirmContacts = firm.Contacts.Select(x => new FirmContact()
					{
						Name = x.Name,
						Mail = x.Mail,
						Phone = x.Phone
					}).ToList()
				};

				context.Firms.Add(save);
				context.SaveChanges();
			}
			return true;
		}

		public static bool RemoveFirm(int firmId)
		{
			using (var context = new EntitiesDB())
			{
				if (context.Firms.Any() == false)
				{
					return false;
				}

				var selectFirm = context.Firms.FirstOrDefault(a => a.Id == firmId);

				if (selectFirm == null)
				{
					return false;
				}

				context.Firms.Remove(selectFirm);
				context.SaveChanges();

				return true;
			}
		}

		//Update Firm

		//Add and remove Address
		//Add and remove Contact
	}
}
