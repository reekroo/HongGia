namespace HongGia.Core.Interfaces.Base
{
	public interface IImage
	{
		int Id { get; set; }
		string Src { get; set; }
		string Alt { get; set; }
		string Type { get; set; }
	}
}
