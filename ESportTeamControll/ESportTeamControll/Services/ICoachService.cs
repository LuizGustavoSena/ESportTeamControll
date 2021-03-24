using ESportTeamControll.Models;
using System.Collections.Generic;

namespace ESportTeamControll.Services
{
    public interface ICoachService
    {
        List<Coach> GetAll();
        void Insert(Coach coach);
        Coach Search(int id);
        void Update(Coach coach);
        void Delete(int id);
    }
}