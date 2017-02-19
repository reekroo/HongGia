using System.Collections.Generic;
using System.Linq;

using HongGia.DB.Models;

using Firm = HongGia.Core.Models.Base.Firm;

namespace HongGia.DB.Services
{
    public class FirmService
    {
        public static IEnumerable<Firm> GetFirms()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Firms.Any() == false)
                {
                    return null;
                }

                var result = context.Firms.Select(f => new Firm()
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
                    }),
                    Contacts = f.FirmContacts.Select(a => new HongGia.Core.Models.Base.FirmContact()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Mail = a.Mail,
                        Phone = a.Phone
                    })
                });

                return result;
            }
        }

        //Update Firm
        //Add and remove Firm

        //Add and remove Address

        //Add and remove Contact
    }
}
