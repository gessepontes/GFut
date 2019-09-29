
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context)
: base(context)
        {

        }

        public IEnumerable<Player> GetPlayerTeam(int id)
        {
            return Db.Players.Where(p => p.Team.PersonId == id && p.Team.Active == true && p.Active == true).OrderBy(p=>p.Name).ToList();
        }

        public override void Update(Player obj)
        {
            Db.Entry(obj).State = EntityState.Modified;

            if (obj.Picture == null)
            {
                Db.Entry(obj).Property("FOTO").IsModified = false;
            }
            else
            {
                string sFoto = obj.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                //Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);
                obj.Picture = sFoto;
            }

            Db.Entry(obj).Property("DATACADASTRO").IsModified = false;
            Db.Entry(obj).Property("DATADISPENSA").IsModified = false;
            Db.Entry(obj).Property("STATUS").IsModified = false;



            Db.SaveChanges();
        }

        public override void Add(Player obj)
        {
            if (obj.Picture == null)
            {
                obj.Picture = "semimagem.png";
            }
            else
            {
                string sFoto = obj.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                //Diverso.SaveCoverPicture(obj.FOTO, "FotoJogador", sFoto);

                obj.Picture = sFoto;
            }


            Db.Add(obj);
            Db.SaveChanges();
        }

        public override void Remove(int id)
        {
            Player player = Db.Players.Find(id);
            player.Active = false;
            Db.Entry(player).State = EntityState.Modified;
            Db.SaveChanges();
        }
    }
}