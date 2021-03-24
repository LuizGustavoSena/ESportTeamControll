using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESportTeamControll.Dal
{
    public class ESportTeamContext : DbContext
    {
        public ESportTeamContext() : base("ESportTeam")
        {

        }
        public DbSet<Camp> Camps { get; set; } 
        public DbSet<Coach> Coachs { get; set; } 
        public DbSet<Enterprise> Enterprises { get; set; } 
        public DbSet<Game> Games { get; set; } 
        public DbSet<Player> Players { get; set; } 
        public DbSet<Sponsor> Sponsors { get; set; } 
        public DbSet<Team> Teams { get; set; } 
        public DbSet<User> Users { get; set; }



    }
}