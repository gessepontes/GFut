using GFut.Domain.Models;
using GFut.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GFut.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {

        // private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            //_env = env;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(config);
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
            modelBuilder.ApplyConfiguration(new HoraryPriceMap());
            modelBuilder.ApplyConfiguration(new HoraryMap());
            modelBuilder.ApplyConfiguration(new SchedulingMap());
            modelBuilder.ApplyConfiguration(new ChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchMap());

            modelBuilder.ApplyConfiguration(new MatchChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchPlayerChampionshipMap());
            modelBuilder.ApplyConfiguration(new MatchPlayerMap());
            modelBuilder.ApplyConfiguration(new PlayerRegistrationMap());
            modelBuilder.ApplyConfiguration(new SubscriptionMap());
            modelBuilder.ApplyConfiguration(new PageMap());
            modelBuilder.ApplyConfiguration(new PageProfileMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonProfile> PersonProfile { get; set; }
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
        public DbSet<HoraryPrice> HoraryPrices { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PlayerRegistration> PlayerRegistrations { get; set; }
        public DbSet<GroupChampionship> GroupChampionships { get; set; }
        public DbSet<MatchChampionship> MatchChampionships { get; set; }
        public DbSet<MatchPlayerChampionship> MatchPlayerChampionships { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageProfile> PageProfiles { get; set; }
        

    }
}
