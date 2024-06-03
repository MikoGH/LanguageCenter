using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByGroupId
{
	public record GetGroupClientByGroupIdQuery(int groupId) : IRequest<IEnumerable<GroupClientEntity>>;
}
