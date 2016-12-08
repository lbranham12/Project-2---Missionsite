using MissionSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionSite.DAL;
using System.Data.SqlClient;
using System.Data.Entity;

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

        
        public ActionResult MissionFAQs(int? Mission_ID)
        {
            //string missionName
            //Missions tempMission = db.mission.SingleOrDefault(mission1 => mission1.name == missionName);
           


            //int missionid;
            //Missions tempMission = db.mission.FirstOrDefault(mission1 => mission1.name == missionName && mission1.Mission_ID == missionid);
            
            //missionid = tempMission.Mission_ID;
            //if (missionName != null){
            if (Mission_ID != null){
                List<MissionQuestions> questions = new List<MissionQuestions> { };
                foreach (var quest in db.missionquestion)
                {
                    if(quest.Mission_ID == Mission_ID){
                        questions.Add(quest);
                    }
                }



                Missions tempMission = db.mission.Find(Mission_ID);
                ViewBag.MissionID = tempMission.Mission_ID;
                ViewBag.MissionName = tempMission.name;
                ViewBag.PresName = tempMission.president;
                ViewBag.MissionAddress = tempMission.streetaddress;
                ViewBag.MissionLanguage = tempMission.language;
                ViewBag.MissionClimate = tempMission.climate;
                ViewBag.MissionReligion = tempMission.religion;
                ViewBag.MissionFlag = tempMission.flag;


                return View(questions);
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

        //how to post questions
        [HttpPost]
        public ActionResult postQuestion(FormCollection form)
        {
            int tempMissionIDs = Convert.ToInt32(form["hdnMission"]);
            int tempUserID = 1;
            tempUserID = Convert.ToInt32(Session["userID"]);
            string tempQuestion = form["Question"].ToString();
            string tempAnswer = "No answer has been given.";
            MissionQuestions temp = new MissionQuestions { Mission_ID = tempMissionIDs, User_ID = tempUserID, question = tempQuestion, answer = tempAnswer };
            db.missionquestion.Add(temp);
            db.SaveChanges();
            return RedirectToAction("MissionFAQs", "Missions", new { Mission_ID = tempMissionIDs });
        }

        public ActionResult answerQuestion(FormCollection form, int MissionQuestion_ID, int Mission_ID)
        {
            //load the db object based on the id given in parameters (missionQuestionID)
            MissionQuestions tempQuestion = db.missionquestion.Find(MissionQuestion_ID);
            int tempMissionIDs = Mission_ID;
            string tempAnswer = form["Answer"].ToString();
            //Question temp = new Question { Mission_ID = tempMissionIDs, User_ID = tempUserID, question = tempQuestion, answer = tempAnswer };
            tempQuestion.answer = tempAnswer;
            db.Entry(tempQuestion).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MissionFAQs", "Missions", new { Mission_ID = tempMissionIDs });
        }
    }
}