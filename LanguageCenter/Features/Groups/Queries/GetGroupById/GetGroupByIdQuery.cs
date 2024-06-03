using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Groups.Queries.GetGroupById
{
	public record GetGroupByIdQuery(int id) : IRequest<GroupEntity>;
}
