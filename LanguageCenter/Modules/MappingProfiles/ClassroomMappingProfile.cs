using AutoMapper;
using LanguageCenter.Features.Classrooms.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class ClassroomMappingProfile : Profile
	{
		public ClassroomMappingProfile()
		{
			CreateMap<UpdateClassroomDto, ClassroomEntity>();
			CreateMap<InsertClassroomDto, ClassroomEntity>();
		}
	}
}
