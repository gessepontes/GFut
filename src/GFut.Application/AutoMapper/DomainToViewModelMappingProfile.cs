using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using System.Linq;

namespace GFut.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>()
                .ForMember(dst => dst.ProfileType,
                    map => map.MapFrom(src => src.PersonProfiles.Select(x => x.ProfileType))).MaxDepth(1);

            CreateMap<Player, PlayerViewModel>().MaxDepth(1);
            CreateMap<Team, TeamViewModel>().MaxDepth(1);
            CreateMap<Championship, ChampionshipViewModel>().MaxDepth(1);
            CreateMap<Field, FieldViewModel>().MaxDepth(1);
            CreateMap<FieldItem, FieldItemViewModel>().MaxDepth(1);
            CreateMap<HoraryPrice, HoraryPriceViewModel>().MaxDepth(1);
            CreateMap<Horary, HoraryViewModel>().MaxDepth(1);
            CreateMap<HoraryExtra, HoraryExtraViewModel>().MaxDepth(1);
            CreateMap<Scheduling, SchedulingViewModel>().MaxDepth(1);
            CreateMap<User, UserViewModel>().MaxDepth(1);
            CreateMap<Subscription, SubscriptionViewModel>().MaxDepth(1);
            CreateMap<PlayerRegistration, PlayerRegistrationViewModel>().MaxDepth(1);
            CreateMap<GroupChampionship, GroupChampionshipViewModel>().MaxDepth(1);

            CreateMap<MatchChampionship, MatchChampionshipViewModel>()
                .ForMember(x => x.GuestSubscription, x => x.MapFrom(c => c.GuestSubscription));

            CreateMap<MatchChampionship, MatchChampionshipViewModel>()
                .ForMember(x => x.HomeSubscription, x => x.MapFrom(c => c.HomeSubscription));
        }
    }
}
