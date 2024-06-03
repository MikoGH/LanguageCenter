using MediatR;

namespace LanguageCenter.Features.Groups.Queries.ExistsGroupById
{
	public record ExistsGroupByIdQuery(int id) : IRequest<bool>;
}
