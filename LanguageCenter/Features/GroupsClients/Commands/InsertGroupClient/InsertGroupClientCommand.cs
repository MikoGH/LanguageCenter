using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Commands.InsertGroupClient
{
	public record InsertGroupClientCommand(GroupClientEntity groupClient) : IRequest<GroupClientEntity>;
}
