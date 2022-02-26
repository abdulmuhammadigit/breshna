using AutoMapper;
using Pro.Entities;
using Pro.ViewModels.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.DataAccess.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){

            CreateMap<Owner, OwnerViewModel>();
        }
    }
}
