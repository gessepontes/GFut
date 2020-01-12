using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return Db.Teams.Where(p => p.PersonId == id && p.Active == true).OrderBy(p => p.Name).ToList();
        }

        public override void Update(Team obj)
        {

            if (obj.Active) {
                foreach (var item in Db.Teams.Where(p => p.PersonId == obj.PersonId && p.State == true && p.Active == true).ToList())
                {
                    Db.Entry(item).State = EntityState.Modified;
                    item.Active = false;
                    Db.SaveChanges();
                }  
            }

            Db.Entry(obj).State = EntityState.Modified;           

            if (obj.Symbol == null)
            {
                Db.Entry(obj).Property("Symbol").IsModified = false;
            }
            else
            {
                string sFoto = obj.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                //Diverso.SaveCoverPicture(obj.FOTO, "Simbolo", sFoto);
                obj.Symbol = sFoto;
            }

            Db.Entry(obj).Property("RegisterDate").IsModified = false;
            Db.Entry(obj).Property("State").IsModified = false;

            obj.Picture = "semimagem.png";

            Db.SaveChanges();
        }

        public override void Add(Team obj)
        {
            if (obj.Active)
            {
                foreach (var item in Db.Teams.Where(p => p.PersonId == obj.PersonId && p.State == true && p.Active == true).ToList())
                {
                    Db.Entry(item).State = EntityState.Modified;
                    item.Active = false;
                    Db.SaveChanges();
                }
            }

            if (obj.Symbol == null)
            {
                obj.Symbol = "semimagem.png";
            }
            else
            {
                string sFoto = obj.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                //Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);

                obj.Symbol = sFoto;
            }

            obj.Picture = "semimagem.png";

            Db.Add(obj);
            Db.SaveChanges();
        }

        public override void Remove(int id)
        {
            Team team = Db.Teams.Find(id);
            team.State = false;
            Db.Entry(team).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}
