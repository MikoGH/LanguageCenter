using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetPersonByLogin
{
	public class GetPersonByLoginHandler : IRequestHandler<GetPersonByLoginQuery, PersonEntity>
	{
		private readonly IPersonRepository personRepository;
		public GetPersonByLoginHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<PersonEntity> Handle(GetPersonByLoginQuery request, CancellationToken cancellationToken)
		{
			return await personRepository.GetByLoginAsync(request.login, cancellationToken);
		}
	}
}
