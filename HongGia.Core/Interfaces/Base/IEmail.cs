namespace HongGia.Core.Interfaces.Base
{
	public interface IEmail
	{
		string Name { get; set; }
		string Mail { get; set; }
		string Subject { get; set; }
		string Message { get; set; }
	}
}
