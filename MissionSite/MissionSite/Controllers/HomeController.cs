using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MissionSite.Controllers
{
    //this is the home controller that houses many of the views including the main page, about page, maps, and contact page.
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

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[STAThread]
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            //this controller sends the email with the information from users of the website
            string email = form["email"].ToString();
            String APIKey = "b54b981c4ec4ddb9e7e70d2b0d417ba8";
            String SecretKey = "d6a6e50a9f77caff2d3b90a0c2bf5ccf";
            String From = "lbranham.cet@gmail.com";
            String To = "lbranham.cet@gmail.com";
            string subject = "Message from No Fears User";
            string body = form["message"].ToString();

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(From);

            msg.To.Add(new MailAddress(To));

            msg.Subject = subject;
            msg.Body = body + ". This email came from: "+ email;

            SmtpClient client = new SmtpClient("in.mailjet.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(APIKey, SecretKey);

            client.Send(msg);
            return View();
        }
        

        public ActionResult Maps(string missionName)
        {
            if (missionName == "Barcelona")
            {
                ViewBag.MissionName = "Spain Barcelona Mission";
                ViewBag.Map = "../Content/Images/" + missionName +".png";
            }
            else if (missionName =="Malaga")
            {
                ViewBag.MissionName = "Spain Malaga Mission";
                ViewBag.Map = "../Content/Images/" + missionName + ".png";
            }
            else if (missionName == "Arcadia")
            {
                ViewBag.MissionName = "California Arcadia Mission";
                ViewBag.Map = "../Content/Images/" + missionName +".png";
            }
            else
            {
                ViewBag.Map = "../Content/Images/world.jpg";
            }
            return View();
        }
    }
}