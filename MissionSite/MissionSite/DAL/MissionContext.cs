using MissionSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MissionSite.DAL
{
    public class MissionContext:DbContext
    {
        public MissionContext()
            : base("MissionContext")
        {

        }
        //this page is the context page
        public DbSet<Missions> mission { get; set; }
        public DbSet<Users> user { get; set; }
        public DbSet<MissionQuestions> missionquestion { get; set; }

    }
}