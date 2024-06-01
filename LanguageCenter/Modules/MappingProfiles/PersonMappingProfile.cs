using AutoMapper;
using LanguageCenter.Features.Persons.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class PersonMappingProfile : Profile
	{
		public PersonMappingProfile()
		{
			CreateMap<UpdatePersonDto, PersonEntity>();
			CreateMap<InsertPersonDto, PersonEntity>();
			CreateMap<PersonEntity, LogInPersonDto>();
			CreateMap<PersonEntity, GetPersonDto>();
		}
	}
}
