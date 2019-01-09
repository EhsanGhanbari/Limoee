using System;
using System.Diagnostics;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;

namespace Limoee.Web.UI
{
    public class EmailService : IIdentityMessageService
    {
        static readonly SmtpSection Section = WebConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;
        static readonly MailAddress From = new MailAddress(Section.From);

        public async Task SendAsync(IdentityMessage message)
        {
            var m = new MailMessage
            {
                From = From,
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

            m.To.Add(message.Destination);

            try
            {
                using (var c = new SmtpClient())
                    await c.SendMailAsync(m);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            // Plug in your email service here to send an email.
            //return Task.FromResult<int>(0);
        }
    }
}