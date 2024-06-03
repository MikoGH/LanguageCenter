using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.GroupsClients.Commands.DeleteGroupClient
{
	public record DeleteGroupClientCommand(GroupClientEntity groupClient) : IRequest<bool>;
}
