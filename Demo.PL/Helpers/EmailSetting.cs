using Demo.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helpers
{
	public static class EmailSetting
	{
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com",587);
			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("ahmedgbreel996@gmail.com", "pmqk yijc slfz ekwy");
			client.Send("ahmedgbreel996@gmail.com", email.To, email.Subject, email.Body);

		}
	}
}
