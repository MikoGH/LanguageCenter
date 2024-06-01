using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetPersonById
{
	public record GetPersonByIdQuery(int id) : IRequest<PersonEntity>;
}
