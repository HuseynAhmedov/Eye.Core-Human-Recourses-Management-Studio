using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Hepler
{
    public static class EmailManager
    {
        public static void Email(string toEmail, string BodyStr)
        {
            //string htmlString = System.IO.File.ReadAllText(bodyPath);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("pustok.service.test@gmail.com");
            message.To.Add(new MailAddress(toEmail));
            message.Subject = "Your Order";
            message.IsBodyHtml = true;
            message.Body = BodyStr;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("pustok.service.test@gmail.com", "Pustok1234");
            smtp.Send(message);
        }
    }
}
