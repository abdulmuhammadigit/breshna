using AutoMapper;
using Pro.Entities;
using Pro.Entities.identity;
using Pro.ViewModels.Manage;
using Pro.ViewModels.RoleManager;
using Pro.ViewModels.UserManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.IocConfig.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {


            CreateMap<Role, RolesViewModel>().ReverseMap()
                    .ForMember(p => p.Users, opt => opt.Ignore())
                    .ForMember(p => p.Claims, opt => opt.Ignore());


            CreateMap<Role, RolesViewModel>().ReverseMap()
                    .ForMember(p => p.Users, opt => opt.Ignore())
                    .ForMember(p => p.Claims, opt => opt.Ignore());




            CreateMap<User, ProfileViewModel>().ReverseMap()
                .ForMember(p => p.Roles, opt => opt.Ignore())
                   .ForMember(p => p.Claims, opt => opt.Ignore());

            CreateMap<User, UsersViewModel>().ReverseMap()
             .ForMember(p => p.Roles, opt => opt.Ignore())
                .ForMember(p => p.Claims, opt => opt.Ignore());


        }
    }
}
