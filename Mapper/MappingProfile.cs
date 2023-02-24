using AutoMapper;
using rsiot.DataTransferObjects;
using rsiot.Models;

namespace rsiot.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoachForManipulationDto, Coach>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.TrainPrograms, opt => opt.Ignore());
            CreateMap<TrainProgramForManipulationDto, TrainProgram>()
                .ForMember(t => t.Id, opt => opt.Ignore())
                .ForMember(t => t.CoachId, opt => opt.Ignore())
                .ForMember(t => t.Coach, opt => opt.Ignore())
                .ForMember(t => t.Users, opt => opt.Ignore());
            CreateMap<UserForManipulationDto, User>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.TrainPrograms, opt => opt.Ignore());
        }
    }
}
