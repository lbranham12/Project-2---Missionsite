using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionSite.Controllers
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