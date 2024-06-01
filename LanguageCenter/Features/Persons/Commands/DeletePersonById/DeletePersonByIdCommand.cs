using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.DeletePersonById
{
	public record DeletePersonByIdCommand(int id) : IRequest<bool>;
}
