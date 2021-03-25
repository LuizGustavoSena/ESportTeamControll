using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Models
{
    public class Player : Person
    {
        public string NickName { get; set; }
        public string Function { get; set; }
        public virtual Team Team { get; set; }
    }
}