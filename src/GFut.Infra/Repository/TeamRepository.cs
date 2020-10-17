﻿using System.Collections.Generic;
using System.Linq;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context)
          : base(context)
        {

        }

        public IEnumerable<Team> GetTeamPerson(int id)
        {
            return Db.Teams.Where(p => p.PersonId == id && p.State == true).OrderBy(p => p.Name);
        }

        public override IQueryable<Team> GetAll()
        {
            return Db.Teams.Where(p => p.State == true).OrderBy(p => p.Name).AsQueryable();
        }

        public override Team GetById(int id)
        {
            return Db.Teams.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
