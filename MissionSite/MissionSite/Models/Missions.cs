using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//current version!!!! 12-7-2016
namespace MissionSite.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        [HiddenInput(DisplayValue= false)]
        public int Mission_ID { get; set; }

        [Display(Name = "Mission Name")]
        public string name { get; set; }

        [Display(Name = "Mission President")]
        public string president { get; set; }

        [Display(Name = "Mission Address")]
        public string streetaddress { get; set; }

        [Display(Name = "Mission Language")]
        public string language { get; set; }

        [Display(Name = "Mission Climate")]
        public string climate { get; set; }

        [Display(Name = "Mission Dominant Religion")]
        public string religion { get; set; }

        [Display(Name = "Mission Flag")]
        public string flag { get; set; }


    }
}