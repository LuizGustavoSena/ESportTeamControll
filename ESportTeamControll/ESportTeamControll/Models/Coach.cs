using System;

namespace ESportTeamControll.Models
{
    public class Coach : Person
    {
        public string NickName { get; set; }
        public bool Available { get; set; }
    }
}