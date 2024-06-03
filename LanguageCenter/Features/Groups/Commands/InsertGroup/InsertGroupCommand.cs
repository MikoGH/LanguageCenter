using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Groups.Commands.InsertGroup
{
	public record InsertGroupCommand(GroupEntity group) : IRequest<GroupEntity>;
}
