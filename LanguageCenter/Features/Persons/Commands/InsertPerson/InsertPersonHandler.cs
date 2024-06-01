using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.InsertPerson
{
	public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonEntity>
	{
		private readonly IPersonRepository personRepository;
		public InsertPersonHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<PersonEntity> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
		{
			return await personRepository.InsertAsync(request.person, cancellationToken);
		}
	}
}
