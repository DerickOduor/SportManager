using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SportManager.Models.Utils
{
    public class Mail
    {
        public static async Task SendMail(List<Message> Messages, string From, string EmailFromAddress, string EmailPassword)
        {
            var fromAddress = new MailAddress(EmailFromAddress, From);
            try
            {
                if (Messages != null)
                {
                    foreach (var Message in Messages)
                    {
                        var toAddress = new MailAddress(Message.RecepientAddress, Message.RecepientName);
                        string fromPassword = EmailPassword;
                        string subject = Message.MessageSubject;
                        string body = Message.MessageText;

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                    }
                }
            }
            catch (Exception e) { }
        }
    }
}
