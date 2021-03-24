﻿using ESportTeamControll.Models;
using System.Collections.Generic;

namespace ESportTeamControll.Services
{
    public interface ITeamService
    {
        List<Team> Retorna();

        void Adiciona(Team teams);

        void SaveChanges();

        Team ProcuraId(int id);

        void RemoverTime(int id);

        void Edit(Team teams);
    }
}