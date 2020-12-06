using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GFut.Infra.Data.Context;
using static GFut.Domain.Others.Enum;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        public PersonRepository(AppDbContext context)
  : base(context)
        {

        }

        public async Task<Person> Authenticate(string email, string password)
        {
            var _pessoa = await Db.People.Include(x => x.PersonProfiles).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            if (_pessoa == null)
                return null;

            //_pessoa.token = Diverso.GetBuildToken(_pessoa.EMAIL);
            return _pessoa;
        }

        public override async Task<IEnumerable<Person>> GetAll()
        {
            var _data = await Db.People.Include(x => x.PersonProfiles).ToListAsync();
            return _data;
        }

        public async Task<IEnumerable<Person>> GetPersonAllDrop()
        {
            var _data = await Db.People.ToListAsync();
            return _data;
        }

        public async Task<IEnumerable<Person>> GetPersonChampionshipDrop()
        {
            var listPerson = await (from p in Db.People
                                    join
                                       pp in Db.PersonProfile on p.Id equals pp.PersonId into ppp
                                    from ppp2 in ppp
                                    where ppp2.ProfileType == ProfileType.AdministradorCampeonato
                                    select new Person { Id = p.Id, Name = p.Name }).ToListAsync();

            return listPerson;
        }

        public async Task<IEnumerable<Person>> GetPersonFieldDrop()
        {
            var listPerson = await (from p in Db.People
                                    join
                                       pp in Db.PersonProfile on p.Id equals pp.PersonId into ppp
                                    from ppp2 in ppp
                                    where ppp2.ProfileType == ProfileType.AdministradorCampo
                                    select new Person { Id = p.Id, Name = p.Name }).ToListAsync();

            return listPerson;
        }

        public override async Task<Person> GetById(int id)
        {
            Person _p = await Db.People.Include(x => x.PersonProfiles).FirstOrDefaultAsync(x => x.Id == id);

            _p.Password = "";
            return _p;
        }
    }
}
