using AutoMapper;
using D.DbSchema.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSchema.Server.Models
{
    public class MvcDtoModelsToOtherProfile : Profile
    {
        public MvcDtoModelsToOtherProfile()
        {
            CreateMap<ProjectAddModel, Project>();
        }
    }
}
