using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CapSoft.Core.Models;
using CapSoft.Core.ViewModels;

namespace CapSoft.Core.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
         
            Mapper.CreateMap<User, UserViewModel>();
            
        }
    }
}