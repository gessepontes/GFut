using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Domain.Others;
using System.Linq;
using GFut.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace GFut.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(AppDbContext context)
  : base(context)
        {

        }

        public void UpdateUser(User user)
        {
            Person person = Db.People.Find(user.Id);

            person.Name = user.Name;
            person.Phone = user.Phone;
            person.BirthDate = user.BirthDate;
            person.Picture = user.Picture;

            if (user.Password != null)
            {
                person.Password = user.Password;
            }

            Db.People.Update(person);
            Db.SaveChanges();
        }

        public Person SignIn(User user)
        {
            var person = Db.People.Include(t => t.Teams).Include(p => p.PersonProfiles).FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (person == null)
                return null;

            return person;
        }
    }
}
