using AutoMapper;
using GFut.Application.ViewModels;
using GFut.Domain.Models;

namespace GFut.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
            CreateMap<TeamViewModel, Team>();
            CreateMap<PlayerViewModel, Player>();
            CreateMap<ChampionshipViewModel, Championship>();


            //CreateMap<PersonViewModel, RegisterNewPersonCommand>()
            //    .ConstructUsing(c => new RegisterNewPersonCommand(c.Name, c.Email, c.BirthDate));
            //CreateMap<PersonViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
