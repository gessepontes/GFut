using GFut.Domain.Models;
using Microsoft.EntityFrameworkCore;
using GFut.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GFut.Infra.Data.Context;

namespace GFut.Infra.Data.Repository
{
    public class ChampionshipRepository : Repository<Championship>, IChampionshipRepository
    {

        public ChampionshipRepository(AppDbContext context)
  : base(context)
        {

        }

        public IEnumerable<Championship> GetChampionshipInscription(int id)
        {
            // ICollection<int> listaInscricao = Db.Inscriptions.Where(p => p.IdTeam == id).Select(s => s.Id).ToList();

            //return Db.Championships.Include(p => p.Subscribed).Where(p => listaInscricao.Contains(p.Id));
            return Db.Championships.Include(p => p.Person);
        }

        public override IQueryable<Championship> GetAll()
        {
            var listChampionship = from p in Db.Championships
                                   select new Championship { Id = p.Id, Name = p.Name, PersonId = p.PersonId, Picture = p.Picture, PlayerRegistration = p.PlayerRegistration, RefereeType = p.RefereeType,
                                   RegisterDate = p.RegisterDate, ReleaseSubscription = p.ReleaseSubscription, StartDate = p.StartDate, Active = p.Active, AmountTeam = p.AmountTeam, 
                                   ChampionshipType = p.ChampionshipType,EndDate = p.EndDate, Type = p.Type, FieldId = p.FieldId, GoBack = p.GoBack};
            return listChampionship;
        }

        public IEnumerable<Championship> GetPreInscription() => Db.Championships.Where(p => p.ReleaseSubscription == true);

    }
}
