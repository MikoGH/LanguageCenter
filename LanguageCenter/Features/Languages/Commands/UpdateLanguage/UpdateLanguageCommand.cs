using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Languages.Commands.UpdateLanguage
{
	public record UpdateLanguageCommand(LanguageEntity language) : IRequest<LanguageEntity>;
}
