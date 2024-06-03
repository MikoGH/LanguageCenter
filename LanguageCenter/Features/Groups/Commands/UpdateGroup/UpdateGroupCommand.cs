using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Groups.Commands.UpdateGroup
{
	public record UpdateGroupCommand(GroupEntity group) : IRequest<GroupEntity>;
}
