using MediatR;

namespace LanguageCenter.Features.Languages.Queries.ExistsLanguageById
{
	public record ExistsLanguageByIdQuery(int id) : IRequest<bool>;
}
