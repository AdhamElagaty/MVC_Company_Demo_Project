using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Company_Demo_Project.Service.Helpers
{
    public static class EmailSettings
    {
        public static void SendEmail(Email input)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("adhamalagaty@gmail.com", "qkqwuyevjrjotvtg");
            client.Send("adhamalagaty@gmail.com", input.To, input.Subject, input.Body);
        }
    }
}
