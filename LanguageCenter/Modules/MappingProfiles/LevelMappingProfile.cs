using AutoMapper;
using LanguageCenter.Features.Courses.Dtos;
using LanguageCenter.Features.Levels.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class LevelMappingProfile : Profile
	{
		public LevelMappingProfile()
		{
			CreateMap<UpdateLevelDto, LevelEntity>();
			CreateMap<InsertLevelDto, LevelEntity>();
		}
	}
}
