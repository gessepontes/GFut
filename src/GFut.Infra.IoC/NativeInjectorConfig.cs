using GFut.Application.Interfaces;
using GFut.Application.Services;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;
using GFut.Infra.Data.Repository;
using GFut.Infra.Data.SocietyPro.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GFut.Infra.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Infra - Data
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonProfileRepository, PersonProfileRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<IFieldItemRepository, FieldItemRepository>();
            services.AddScoped<IHoraryPriceRepository, HoraryPriceRepository>();
            services.AddScoped<IHoraryRepository, HoraryRepository>();
            services.AddScoped<IHoraryExtraRepository, HoraryExtraRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IChampionshipRepository, ChampionshipRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IPlayerRegistrationRepository, PlayerRegistrationRepository>();
            services.AddScoped<IGroupChampionshipRepository, GroupChampionshipRepository>();
            services.AddScoped<IMatchChampionshipRepository, MatchChampionshipRepository>();
            services.AddScoped<IMatchPlayerChampionshipRepository, MatchPlayerChampionshipRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPageProfileRepository, PageProfileRepository>();

            services.AddScoped<IMigrationsSocietyProToGFutRepository, MigrationsSocietyProToGFutRepository>();

            services.AddScoped<AppDbContext>();

            // Application
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<ITeamAppService, TeamAppService>();
            services.AddScoped<IPlayerAppService, PlayerAppService>();
            services.AddScoped<IChampionshipAppService, ChampionshipAppService>();
            services.AddScoped<IFieldAppService, FieldAppService>();
            services.AddScoped<IFieldItemAppService, FieldItemAppService>();
            services.AddScoped<IHoraryPriceAppService, HoraryPriceAppService>();
            services.AddScoped<IHoraryAppService, HoraryAppService>();
            services.AddScoped<IHoraryExtraAppService, HoraryExtraAppService>();
            services.AddScoped<ISchedulingAppService, SchedulingAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ISubscriptionAppService, SubscriptionAppService>();
            services.AddScoped<IPlayerRegistrationAppService, PlayerRegistrationAppService>();
            services.AddScoped<IGroupChampionshipAppService, GroupChampionshipAppService>();
            services.AddScoped<IMatchChampionshipAppService, MatchChampionshipAppService>();
            services.AddScoped<IStandingsAppService, StandingsAppService>();
            services.AddScoped<ITopScorersAppService, TopScorersAppService>();
            services.AddScoped<ISuspendedPlayersAppService, SuspendedPlayersAppService>();
            services.AddScoped<IMatchSummaryAppService, MatchSummaryAppService>();
            services.AddScoped<IPageAppService, PageAppService>();
            services.AddScoped<IPageProfileAppService, PageProfileAppService>();


            services.AddScoped<IMigrationsSocietyProToGFutAppService, MigrationsSocietyProToGFutAppService>();
        }
    }
}
