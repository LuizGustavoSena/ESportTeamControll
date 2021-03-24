using ESportTeamControll.Models;
using System.Collections.Generic;

namespace ESportTeamControll.Services
{
    public interface ICampService
    {
        List<Camp> GetAll();
        void Insert(Camp camp);
        Camp Search(int id);
        void Update(Camp camp);
        void Delete(int id);
    }
}