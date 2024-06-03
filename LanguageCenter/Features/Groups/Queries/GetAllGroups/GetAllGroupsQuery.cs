using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Groups.Queries.GetAllGroups
{
	public record GetAllGroupsQuery() : IRequest<IEnumerable<GroupEntity>>;
}
