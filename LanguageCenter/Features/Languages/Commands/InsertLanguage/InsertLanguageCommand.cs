using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Languages.Commands.InsertLanguage
{
	public record InsertLanguageCommand(LanguageEntity language) : IRequest<LanguageEntity>;
}
