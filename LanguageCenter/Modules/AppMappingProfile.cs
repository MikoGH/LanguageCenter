using AutoMapper;
using LanguageCenter.Models.Dto;
using LanguageCenter.Models.Entity;

namespace LanguageCenter.Modules
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UpdateCourseDto, CourseEntity>();
            CreateMap<InsertCourseDto, CourseEntity>();

            CreateMap<UpdatePersonDto, PersonEntity>();
            CreateMap<InsertPersonDto, PersonEntity>();
            CreateMap<PersonEntity, LogInPersonDto>();
			CreateMap<PersonEntity, GetPersonDto>();
		}
    }
}
