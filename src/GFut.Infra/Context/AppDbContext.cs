using GFut.Domain.Models;
using GFut.Infra.Data.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GFut.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {

        private readonly IHostingEnvironment _env;

        public AppDbContext(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonProfileMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new FieldMap());
            modelBuilder.ApplyConfiguration(new FieldItemMap());
            modelBuilder.ApplyConfiguration(new HoraryExtraMap());
            modelBuilder.ApplyConfiguration(new HoraryMap());
            modelBuilder.ApplyConfiguration(new SchedulingMap());
            modelBuilder.ApplyConfiguration(new ChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchMap());

            modelBuilder.ApplyConfiguration(new MatchChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchPlayerChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchPlayerMap());
            modelBuilder.ApplyConfiguration(new PlayerRegistrationMap());
            modelBuilder.ApplyConfiguration(new SubscriptionMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonProfile> PessoaPerfis { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldItem> FieldItens { get; set; }
        public DbSet<HoraryExtra> HoraryExtras { get; set; }
        public DbSet<Horary> Horarys { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
