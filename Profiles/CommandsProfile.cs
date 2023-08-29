using AutoMapper;
using SixMinApi.Dtos;
using SixMinApi.models;

namespace SixMinApi.Profiles{
    public class CommandsProfile : Profile{
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}