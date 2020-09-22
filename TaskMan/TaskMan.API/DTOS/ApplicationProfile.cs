using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskMan.API.DTOS.Tasks;
using TaskMan.Framework.Entities;
using TaskMan.Membership.Entities;

namespace TaskMan.API.DTOS
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ShowTaskDTO, Task>()
                .ForMember(dest => dest.User,opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTo,opt => opt.Ignore());
            CreateMap<Task, ShowTaskDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo.UserName));
            CreateMap<TaskCreateDTO, Task>();
            CreateMap<User, ShowUserDTO>();
            CreateMap<User, DropUserDTO>();
            CreateMap<List<User>, UserDropDownDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));
        }
    }
}
