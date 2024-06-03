using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Queries.GetGroupClientByPersonId
{
	public record GetGroupClientByPersonIdQuery(int personId) : IRequest<IEnumerable<GroupClientEntity>>;
}
