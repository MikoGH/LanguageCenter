using AutoMapper;
using LanguageCenter.Features.Addresses.Dtos;
using LanguageCenter.Features.Courses.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class AddressMappingProfile : Profile
	{
		public AddressMappingProfile()
		{
			CreateMap<UpdateAddressDto, AddressEntity>();
			CreateMap<InsertAddressDto, AddressEntity>();
		}
	}
}
