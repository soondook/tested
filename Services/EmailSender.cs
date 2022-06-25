using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using tested.Services;

namespace tested
{
    public class EmailSender
    {
        //private readonly mailConfig _config;
        public EmailSender(string host, int port, bool enableSSL, string userName, string passwor)
        {
            using (MailMessage mm = new MailMessage())
            {
                /*
                mm.Subject = _email.Subject;
                mm.Body = _email.Body;
                if (_email.Attachment.Length > 0)
                {
                    string fileName = Path.GetFileName(_email.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(_email.Attachment.OpenReadStream(), fileName));
                }
                mm.IsBodyHtml = false;
                */
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("atmtechportal.for.all@gmail.com", "erqgwvcuobazlpvy");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
            //return null;
        }
    }
}
