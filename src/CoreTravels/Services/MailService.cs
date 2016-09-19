namespace CoreTravels.Services
{
    using System.Diagnostics;

    public class MailService : IMailService
    {
        public void SendMail(string to, string from, string subject, string body)
        {
            Debug.WriteLine($"Sending Mail to: {to} From: {from} Subject {subject}");
        }
    }
}
