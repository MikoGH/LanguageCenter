using MediatR;

namespace LanguageCenter.Features.Languages.Commands.DeleteLanguageById
{
	public record DeleteLanguageByIdCommand(int id) : IRequest<bool>;
}
