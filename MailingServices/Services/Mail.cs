using System.Net;
using System.Net.Mail;

public class Emails
{
    private static readonly string host = "smtp.office365.com";
    private static readonly string username = "auto@oasisoft.net";
    private static readonly string password = "Flatron@1984";
    private static readonly string displayName = "Oasis - IBS";
    private static readonly int port = 587;

    public static void SendEmail(string subject, string body, IList<string> receivers,
                                 ICollection<IFormFile> files = null,
                                 MailPriority priority = MailPriority.Normal)
    {
        var smtpClient = new SmtpClient();
        smtpClient.Host = host;
        smtpClient.Credentials = new NetworkCredential(username, password);
        smtpClient.EnableSsl = true;
        smtpClient.Port = port;

        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(username, displayName);
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.Priority = priority;
        mailMessage.IsBodyHtml = true;

        //Receivers
        foreach (var receiver in receivers)
        {
            mailMessage.To.Add(receiver);
        }

        //Attachments
        if (files != null)
        {
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    var att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                    mailMessage.Attachments.Add(att);
                }
            }
        }

        smtpClient.Send(mailMessage);
    }

    public static void SendEmail(string subject, string body, string receiver,
                                ICollection<IFormFile> files = null,
                                MailPriority priority = MailPriority.Normal)
    {
        var smtpClient = new SmtpClient();
        smtpClient.Host = host;
        smtpClient.Credentials = new NetworkCredential(username, password);
        smtpClient.EnableSsl = true;
        smtpClient.Port = port;

        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(username, displayName);
        mailMessage.Subject = subject;
        mailMessage.Body = body;
        mailMessage.Priority = priority;
        mailMessage.IsBodyHtml = true;

        //Receivers
        mailMessage.To.Add(receiver);

        //Attachments
        if (files != null)
        {
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    var att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                    mailMessage.Attachments.Add(att);
                }
            }
        }

        smtpClient.Send(mailMessage);
    }

    public class Priority
    {
        public static readonly MailPriority Low = MailPriority.Low;
        public static readonly MailPriority Normal = MailPriority.Normal;
        public static readonly MailPriority High = MailPriority.High;
    }
}