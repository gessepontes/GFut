using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<Player, PlayerViewModel>();
            CreateMap<Team, TeamViewModel>();
            CreateMap<Championship, ChampionshipViewModel>();
        }
    }
}
