using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.GetAllPersons
{
	public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonEntity>>
	{
		private readonly IPersonRepository personRepository;
		public GetAllPersonsHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<IEnumerable<PersonEntity>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
		{
			return await personRepository.GetAllAsync(cancellationToken);
		}
	}
}
