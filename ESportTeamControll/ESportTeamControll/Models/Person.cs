using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}