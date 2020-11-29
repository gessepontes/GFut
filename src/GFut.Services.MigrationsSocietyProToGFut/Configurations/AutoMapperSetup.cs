using AutoMapper;
using GFut.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace GFut.Services.MigrationsSocietyProToGFut.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Auto Mapper Configurations

            IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            services.AddSingleton(mapper);

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project

        }
    }
}
