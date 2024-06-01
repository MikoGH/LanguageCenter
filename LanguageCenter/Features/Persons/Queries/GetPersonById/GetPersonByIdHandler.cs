using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetPersonById
{
	public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonEntity>
	{
		private readonly IPersonRepository personRepository;
		public GetPersonByIdHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<PersonEntity> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
		{
			return await personRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
