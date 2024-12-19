using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "deneme");
            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressto = new MailboxAddress("User", model.ReceiverMail);
            message.To.Add(mailboxAddressto);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("", "");
            client.Send(message);
            client.Disconnect(true);
            return View();
        }
    }
}
