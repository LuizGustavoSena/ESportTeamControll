using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual Game Game { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Camp> Camps { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
    }
}