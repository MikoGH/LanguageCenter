using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.UpdatePerson
{
	public record UpdatePersonCommand(PersonEntity person) : IRequest<PersonEntity>;
}
