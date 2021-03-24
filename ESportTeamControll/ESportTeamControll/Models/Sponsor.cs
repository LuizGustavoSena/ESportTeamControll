﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}