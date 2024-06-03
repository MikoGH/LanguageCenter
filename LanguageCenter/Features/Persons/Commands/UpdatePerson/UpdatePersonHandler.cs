using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Commands.UpdatePerson
{
	public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonEntity>
	{
		private readonly IPersonRepository personRepository;
		public UpdatePersonHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<PersonEntity> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
		{
			return await personRepository.UpdateAsync(request.person, cancellationToken);
		}
	}
}
