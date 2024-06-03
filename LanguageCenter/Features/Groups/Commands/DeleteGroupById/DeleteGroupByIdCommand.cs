using MediatR;

namespace LanguageCenter.Features.Groups.Commands.DeleteGroupById
{
	public record DeleteGroupByIdCommand(int id) : IRequest<bool>;
}
