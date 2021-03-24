using System;
using System.Collections.Generic;

namespace ESportTeamControll.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}