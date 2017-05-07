using HongGia.Core.Interfaces.Base;

namespace HongGia.Core.Models.Base
{
	public class Email : IEmail
	{
		public string Name { get; set; }
		public string Mail { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
