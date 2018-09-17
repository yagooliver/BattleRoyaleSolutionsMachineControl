using AutoMapper;
using BattleRoyaleSolutions.Application.Models;
using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Entities;

namespace BattleRoyaleSolutions.Application.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MachineViewModel, LocalMachineInfo>()
                .ForMember(dest => dest.CommandLogs, opt => opt.Ignore());

            CreateMap<CommandLogViewModel, CommandLog>()
                .ForMember(dest => dest.LocalMachineInfo, opt => opt.Ignore());
        }
    }
}
