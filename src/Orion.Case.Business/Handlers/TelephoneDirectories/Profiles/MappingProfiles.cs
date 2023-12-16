﻿using AutoMapper;
using Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create;
using Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetById;
using Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetList;
using Orion.Case.Entities.Concrete;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TelephoneDirectory, CreateTelephoneDirectoryResponse>().ReverseMap();

            CreateMap<TelephoneDirectory, GetListTelephoneDirectoryListItemDto>().ReverseMap();
            CreateMap<TelephoneDirectory, GetByIdTelephoneDirectoryItemDto>().ReverseMap();

        }
    }
}
