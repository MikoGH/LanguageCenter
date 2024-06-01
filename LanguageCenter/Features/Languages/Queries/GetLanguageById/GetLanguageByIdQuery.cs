using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Languages.Queries.GetLanguageById
{
	public record GetLanguageByIdQuery(int id) : IRequest<LanguageEntity>;
}
