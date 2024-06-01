using AutoMapper;
using LanguageCenter.Features.Languages.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class LanguageMappingProfile : Profile
	{
		public LanguageMappingProfile()
		{
			CreateMap<UpdateLanguageDto, LanguageEntity>();
			CreateMap<InsertLanguageDto, LanguageEntity>();
		}
	}
}
