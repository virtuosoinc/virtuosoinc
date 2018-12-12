using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace MyMotel.Components
{
    public class Email
    {
        public bool SendEmail(string Subject, string Body, string ToMail)
        {
            try
            {
                using (MailMessage mm = new MailMessage("motelmanagementsystem@gmail.com", ToMail))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("motelmanagementsystem@gmail.com", "1234qwer$");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}