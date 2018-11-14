using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Office365SMTP.Models;

namespace Office365SMTP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SendMail()
        {
            Console.WriteLine("Send Mail");
            MailMessage mailMessage = new MailMessage("[YOUR@OUTLOOK.EMAIL]", "[RECEIVER]", "[TITLE]", "[MAIL BODY]");
            mailMessage.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
           
            client.Credentials = new System.Net.NetworkCredential("[YOUR@OUTLOOK.EMAIL]", "[YOUR_PASSWORD]");
            client.EnableSsl = true;
            client.Send(mailMessage);
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
