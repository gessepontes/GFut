using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Domain.Others;
using System.Linq;
using GFut.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GFut.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(AppDbContext context, IConfiguration configuration)
  : base(context)
        {
            _configuration = configuration;
        }

        public async Task<Person> UpdateUser(User user)
        {
            try
            {
                Person person = await Db.People.FindAsync(user.Id);

                Db.Entry(person).State = EntityState.Modified;

                person.Name = user.Name;
                person.Phone = user.Phone;
                person.BirthDate = user.BirthDate;
                person.Picture = user.Picture;

                if (person.Password != "")
                {
                    person.Password = Divers.GenerateMD5(person.Password);
                }
                else
                {
                    Db.Entry(person).Property(x => x.Password).IsModified = false;
                }

                Db.SaveChanges();

                person.Password = "";
            }
            catch (System.Exception e)
            {
                e.Message.ToString();
                throw;
            }


            return null;
        }

        public async Task<Person> SignIn(User user)
        {
            var person = await Db.People.Include(t => t.Teams).Include(p => p.PersonProfiles).FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);

            person.Password = "";

            if (person == null)
                return null;

            return person;
        }
    }
}
