using MediatR;

namespace LanguageCenter.Features.Levels.Queries.ExistsLevelById
{
	public record ExistsLevelByIdQuery(int id) : IRequest<bool>;
}
