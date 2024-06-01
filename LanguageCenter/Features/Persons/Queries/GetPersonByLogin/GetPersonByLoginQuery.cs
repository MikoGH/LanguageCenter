using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetPersonByLogin
{
	public record GetPersonByLoginQuery(string login) : IRequest<PersonEntity>;
}
