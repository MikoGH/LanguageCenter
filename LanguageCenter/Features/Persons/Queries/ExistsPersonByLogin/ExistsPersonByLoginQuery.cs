using MediatR;

namespace LanguageCenter.Features.Persons.Queries.ExistsPersonByLogin
{
	public record ExistsPersonByLoginQuery(string login) : IRequest<bool>;
}
