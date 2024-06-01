using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.InsertPerson
{
	public record InsertPersonCommand(PersonEntity person) : IRequest<PersonEntity>;
}
