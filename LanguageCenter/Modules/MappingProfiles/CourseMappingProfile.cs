using AutoMapper;
using LanguageCenter.Features.Courses.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class CourseMappingProfile : Profile
	{
		public CourseMappingProfile()
		{
			CreateMap<UpdateCourseDto, CourseEntity>();
			CreateMap<InsertCourseDto, CourseEntity>();
		}
	}
}
