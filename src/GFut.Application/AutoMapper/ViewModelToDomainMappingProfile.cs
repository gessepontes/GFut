using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, Person>().MaxDepth(1);
            CreateMap<TeamViewModel, Team>().MaxDepth(1);
            CreateMap<PlayerViewModel, Player>().MaxDepth(1);
            CreateMap<ChampionshipViewModel, Championship>().MaxDepth(1);
            CreateMap<FieldViewModel, Field>().MaxDepth(1);
            CreateMap<FieldItemViewModel, FieldItem>().MaxDepth(1);
            CreateMap<HoraryPriceViewModel, HoraryPrice>().MaxDepth(1);
            CreateMap<HoraryViewModel, Horary>().MaxDepth(1);
            CreateMap<HoraryExtraViewModel, HoraryExtra>().MaxDepth(1);
            CreateMap<SchedulingViewModel, Scheduling>().MaxDepth(1);
            CreateMap<UserViewModel, User>().MaxDepth(1);
            CreateMap<SubscriptionViewModel, Subscription>().MaxDepth(1);
            CreateMap<PlayerRegistrationViewModel,PlayerRegistration>().MaxDepth(1);
            CreateMap<GroupChampionshipViewModel, GroupChampionship>().MaxDepth(1);
            CreateMap<MatchChampionshipViewModel, MatchChampionship>().MaxDepth(1);


            //CreateMap<PersonViewModel, RegisterNewPersonCommand>()
            //    .ConstructUsing(c => new RegisterNewPersonCommand(c.Name, c.Email, c.BirthDate));
            //CreateMap<PersonViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
