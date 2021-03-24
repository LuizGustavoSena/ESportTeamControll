using ESportTeamControll.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ESportTeamControll.Dal
{
    public class CoachInitializer : DropCreateDatabaseIfModelChanges<ESportTeamContext>
    {
        protected override void Seed(ESportTeamContext context)
        {
            var coachs = new List<Coach> { 
                new Coach{Id = 1, Name = "Gaules", BirthDate = DateTime.Parse("05/10/1973"), Cpf = "1", NickName = "RobertinhoAK"},
                new Coach{Id = 2, Name = "Fall", BirthDate = DateTime.Parse("07/17/1987"), Cpf = "2", NickName = "F@ll"}
            };

            coachs.ForEach(i => context.Coachs.Add(i));
            context.SaveChanges();
        }
    }
}