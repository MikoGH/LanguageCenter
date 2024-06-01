using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetAllPersons
{
	public record GetAllPersonsQuery() : IRequest<IEnumerable<PersonEntity>>;
}
