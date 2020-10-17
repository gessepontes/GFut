using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GFut.Infra.Data.Context;
using static GFut.Domain.Others.Enum;

namespace GFut.Infra.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        public PersonRepository(AppDbContext context)
  : base(context)
        {

        }

        public Person Authenticate(string email, string password)
        {
            var _pessoa = Db.People.Include(x => x.PersonProfiles).FirstOrDefault(x => x.Email == email && x.Password == password);

            if (_pessoa == null)
                return null;

            //_pessoa.token = Diverso.GetBuildToken(_pessoa.EMAIL);
            return _pessoa;
        }

        public override IQueryable<Person> GetAll() =>
            Db.People.Include(x => x.PersonProfiles).AsQueryable();


        public IQueryable<Person> GetPersonAllDrop()
        {
            var listPerson = from p in Db.People
                             select new Person { Id = p.Id, Name = p.Name };

            return listPerson;
        }

        public IQueryable<Person> GetPersonChampionshipDrop()
        {
            var listPerson = from p in Db.People
                             join
                                pp in Db.PersonProfile on p.Id equals pp.PersonId into ppp
                             from ppp2 in ppp
                             where ppp2.ProfileType == ProfileType.AdministradorCampeonato
                             select new Person { Id = p.Id, Name = p.Name };

            return listPerson;
        }

        public IQueryable<Person> GetPersonFieldDrop()
        {
            var listPerson = from p in Db.People
                             join
                                pp in Db.PersonProfile on p.Id equals pp.PersonId into ppp
                             from ppp2 in ppp
                             where ppp2.ProfileType == ProfileType.AdministradorCampo
                             select new Person { Id = p.Id, Name = p.Name };

            return listPerson;
        }

        public override Person GetById(int id)
        {
            Person _p = Db.People.Include(x => x.PersonProfiles).FirstOrDefault(x => x.Id == id);

            _p.Password = "";
            return _p;
        }
    }
}
