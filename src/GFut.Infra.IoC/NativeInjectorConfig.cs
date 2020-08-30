using GFut.Application.Interfaces;
using GFut.Application.Services;
using GFut.Domain.Interfaces;
using GFut.Infra.Data.Context;
using GFut.Infra.Data.Repository;
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
        }
    }
}
