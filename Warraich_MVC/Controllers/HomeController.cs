using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Warraich_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string username, string subject, string Email,  string message)
        {
            bool isSent = SendMail(username , Email, subject, message,"Contact");
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public bool SendMail(string Name, string Email, string Subject, string Message,string Type,string Phone="",string Date="",string Time="")
        {

            MailMessage message = new MailMessage();
            message.To.Add("info@warraichmeatscharolais.com");
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            if (Subject!=""&&Subject!=null && Type=="Contact")
            {
                message.Subject = Subject;
            }
            else if (Type == "Contact")
            {
                message.Subject = "Contact Us";
            }
            else
            {
                message.Subject = "Reservation";
            }
           

            string body = "";
            if (Type == "Contact")
            {
                body = "<p>Person Name : " + Name + "</p>";
                body = body + "<p>Email ID : " + Email + "</p>";
                body = body + "<p>Message : " + Message + "</p>";
            }
            else
            {
                body = "<p>Person Name : " + Name + "</p>";
                body = body + "<p>Email ID : " + Email + "</p>";
                body = body + "<p>Phone No : " + Phone + "</p>";
                body = body + "<p>Date : " + Date + "</p>";
                body = body + "<p>Time : " + Time + "</p>";
                body = body + "<p>Message : " + Message + "</p>";
            }
           
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.1and1.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;

        }

        public ActionResult appetizer_menu()
        {
            return View();
        }
        public ActionResult buffet()
        {
            return View();
        }
        public ActionResult catering_menu()
        {
            return View();
        }
        public ActionResult cooked_food()
        {
            return View();
        }
        public ActionResult family_package()
        {
            return View();
        }
        public ActionResult marinated_food()
        {
            return View();
        }
        public ActionResult onsite_catering()
        {
            return View();
        }
        public ActionResult raw_food()
        {
            return View();
        }
        public ActionResult ready_to_serve()
        {
            return View();
        }
        public ActionResult reservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult reservation(string username, string Email, string Phone, string Date, string Time, string message)
        {
            bool isSent = SendMail(username, Email,"",  message, "Reservation",Phone,Date,Time);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult sea_food()
        {
            return View();
        }
        public ActionResult special_menu()
        {
            return View();
        }
        public ActionResult tray()
        {
            return View();
        }
    }
}