using AutoMapper;
using BattleRoyaleSolutions.Application.Models;
using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Entities;

namespace BattleRoyaleSolutions.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<LocalMachineInfo,MachineViewModel>();

            CreateMap<CommandLog, CommandLogViewModel>();
        }
    }
}
