namespace HongGia.Core.Interfaces.Base
{
    public interface IFirmAddress
    {
        int Id { get; set; }

        string Country { get; set; }

        string City { get; set; }

        string Street { get; set; }

        string Home { get; set; }

        string Zip { get; set; }
    }
}
