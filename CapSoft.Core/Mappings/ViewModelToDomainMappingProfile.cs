using AutoMapper;
using CapSoft.Core.Models;
using CapSoft.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapSoft.Core.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
         
        }
    }
}