﻿using MissionSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionSite.DAL;
using System.Data.SqlClient;

namespace MissionSite.Controllers
{
    public class MissionsController : Controller
    {
        private MissionContext db = new MissionContext();
        
        // GET: Missions
        public ActionResult Index()
        {
            IEnumerable<Missions> missionBryce = db.Database.SqlQuery<Missions>("Select * FROM Missions");

           
            return View(db.mission.ToList());
        }

        
        public ActionResult MissionFAQs(string missionName)
        {
            
            if (missionName != null){
                
                Missions tempMission = db.mission.SingleOrDefault(mission1 => mission1.name == missionName);
                ViewBag.MissionName = missionName;
                ViewBag.PresName = tempMission.president;
                ViewBag.MissionAddress = tempMission.streetaddress;
                ViewBag.MissionLanguage = tempMission.language;
                ViewBag.MissionClimate = tempMission.climate;
                ViewBag.MissionReligion = tempMission.religion;
                ViewBag.MissionFlag = tempMission.flag;


                return View();
            }
            else
            {
                return RedirectToAction("Index", "Missions");
            }
            //if (missionName == "Barcelona"){
                //ViewBag.MissionName = "Spain Barcelona Mission";
                //ViewBag.PresName = "President Merrill T. Dayton";
                //ViewBag.MissionAddress= "Calle Calatrava No 10-12, bajos Barcelona, 08017 Barcelona Spain";
                //ViewBag.MissionLanguage = "Spanish";
                //ViewBag.MissionClimate = "Subtropical-Mediterranean Climate";
                //ViewBag.MissionReligion = "Catholicism";
                //ViewBag.MissionFlag = "../Content/Images/barcelonaflag.png";

            //}
            //else if (missionName == "Malaga")
            //{
            //    //ViewBag.MissionName = "Spain Malaga Mission";
            //    //ViewBag.PresName = "President T. DarVel Andersen";
            //    //ViewBag.MissionAddress = "Av. Jesus Santos Rein No 2,3 D-E Edif. Ofisol, Fuengirola 29640 Malaga, Spain";
            //    //ViewBag.MissionLanguage = "Spanish";
            //    //ViewBag.MissionClimate = "Subtropical-Mediterranean Climate";
            //    //ViewBag.MissionReligion = "Catholicism";
            //    //ViewBag.MissionFlag = "../Content/Images/Malaga.jpg";
            //}
            //else if (missionName == "Arcadia")
            //{
            //    //ViewBag.MissionName = "California Arcadia Mission";
            //    //ViewBag.PresName = "President Moises Villanueva";
            //    //ViewBag.MissionAddress = "614 West Foothill Blvd. Arcadia CA 91006-2030 USA";
            //    //ViewBag.MissionLanguage = "Spanish or English";
            //    //ViewBag.MissionClimate = "Mediterranean-like Climate";
            //    //ViewBag.MissionReligion = "Catholicism";
            //    //ViewBag.MissionFlag = "../Content/Images/califlag.png";
            ////}
            //return View();
        }
    }
}