using MediatR;

namespace LanguageCenter.Features.Levels.Commands.DeleteLevelById
{
	public record DeleteLevelByIdCommand(int id) : IRequest<bool>;
}
