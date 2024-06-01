using LanguageCenter.Features.Persons.Queries.ExistsPersonByLogin;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.ExistsPersonById
{
	public class ExistsPersonByIdHandler : IRequestHandler<ExistsPersonByIdQuery, bool>
	{
		private readonly IPersonRepository personRepository;
		public ExistsPersonByIdHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<bool> Handle(ExistsPersonByIdQuery request, CancellationToken cancellationToken)
		{
			return await personRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
