using AutoMapper;
using LanguageCenter.Features.Groups.Dtos;
using LanguageCenter.Models;

namespace LanguageCenter.Modules.MappingProfiles
{
	public class GroupMappingProfile : Profile
	{
		public GroupMappingProfile()
		{
			CreateMap<UpdateGroupDto, GroupEntity>();
			CreateMap<InsertGroupDto, GroupEntity>();
		}
	}
}
