using System.Net;
using System.Net.Mail;

using HongGia.Core.Interfaces.Base;

namespace HongGia.BL.Mailer
{
	public class Mailer
	{
		private string _toMail;
		private IEmail _email;

		public Mailer(IEmail email)
		{
			_email = email;
			_toMail = "paul.davidovski@gmail.com";
		}

		public bool Send()
		{
			if (_email == null)
			{
				return false;
			}

			//var mail = new MailMessage
			//{
			//	From = new MailAddress(_email.Mail)
			//};

			//mail.To.Add(_toMail);
			//mail.Subject = _email.Subject;
			//mail.Body = _email.Message;

			//var smtpServer = new SmtpClient("smtp.gmail.com")
			//{
			//	Port = 587,
			//	Credentials = new System.Net.NetworkCredential(_toMail, "334242343qweASS"),
			//	EnableSsl = true
			//};

			//smtpServer.Send(mail);



			var mail = new MailMessage(_email.Mail, _toMail)
			{
				Subject = _email.Subject,
				Body = _email.Message
			};

			var smtpServer = new SmtpClient
			{
				Port = 25,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Host = "smtp.google.com"
			};

			smtpServer.Send(mail);

			return true;
		}
	}
}
