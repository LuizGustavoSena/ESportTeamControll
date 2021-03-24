using System;

namespace ESportTeamControll.Models
{
    public class User : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}