using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.DeletePersonById
{
	public class DeletePersonByIdHandler : IRequestHandler<DeletePersonByIdCommand, bool>
	{
		private readonly IPersonRepository personRepository;
		public DeletePersonByIdHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<bool> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
		{
			return await personRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
