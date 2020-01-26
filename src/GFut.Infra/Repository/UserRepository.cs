using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using GFut.Domain.Others;
using System.Linq;
using GFut.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GFut.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(AppDbContext context)
  : base(context)
        {

        }

        public Person SignIn(User user)
        {
            var person = Db.People.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (person == null)
                return null;

            return person;
        }

        public void SignUp(User user)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Person person = new Person
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Picture = Divers.Base64ToImage(config.GetSection(key: "Config")["UserBase64"], "PERSON"),
                Confirmation = true,
            };


            Db.People.Add(person);

            PersonProfile personProfile = new PersonProfile
            {
                PersonId = person.Id,
                ProfileType = Enum.ProfileType.Jogador
            };

            Db.PersonProfile.Add(personProfile);
            Db.SaveChanges();

        }
    }
}
