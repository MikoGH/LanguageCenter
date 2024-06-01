using LanguageCenter.Features.Languages.Queries.GetAllLanguages;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Persons.Queries.ExistsPersonByLogin
{
	public class ExistsPersonByLoginHandler : IRequestHandler<ExistsPersonByLoginQuery, bool>
	{
		private readonly IPersonRepository personRepository;
		public ExistsPersonByLoginHandler(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}
		public async Task<bool> Handle(ExistsPersonByLoginQuery request, CancellationToken cancellationToken)
		{
			return await personRepository.ExistsByLoginAsync(request.login, cancellationToken);
		}
	}
}
