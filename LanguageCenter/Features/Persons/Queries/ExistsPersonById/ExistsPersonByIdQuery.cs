using MediatR;

namespace LanguageCenter.Features.Persons.Queries.ExistsPersonById
{
	public record ExistsPersonByIdQuery(int id) : IRequest<bool>;
}
