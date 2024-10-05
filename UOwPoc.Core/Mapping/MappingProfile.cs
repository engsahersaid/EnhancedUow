using AutoMapper;
using UOwPoc.Core.Features.Person.Commands.Create;
using UOwPoc.Core.Features.Person.Commands.Update;
using UOwPoc.Core.Features.Person.Queries.GetById;
using UOwPoc.Core.Features.Person.Queries.GetList;
using UOWPoc.Entities;

namespace UOwPoc.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddPersonDto, Person>();
            CreateMap<AddAddressDto, Address>();

            CreateMap<UpdatePersonDto, Person>();
            CreateMap<UpdateAddressDto, Address>();

            CreateMap<Person, PersonDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Person, PersonListDto>();
        }
    }
}