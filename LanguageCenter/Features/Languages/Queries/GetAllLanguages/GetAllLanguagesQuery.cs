using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Languages.Queries.GetAllLanguages
{
	public record GetAllLanguagesQuery() : IRequest<IEnumerable<LanguageEntity>>;
}
