using AutoMapper;
using LanguageCenter.Features.Schedules.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class ScheduleMappingProfile : Profile
	{
		public ScheduleMappingProfile()
		{
			CreateMap<UpdateScheduleDto, ScheduleEntity>();
			CreateMap<InsertScheduleDto, ScheduleEntity>();
		}
	}
}
