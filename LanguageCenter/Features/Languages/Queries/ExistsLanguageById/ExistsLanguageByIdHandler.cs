using LanguageCenter.Features.Languages.Queries.GetAllLanguages;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Queries.ExistsLanguageById
{
	public class ExistsLanguageByIdHandler : IRequestHandler<ExistsLanguageByIdQuery, bool>
	{
		private readonly ILanguageRepository languageRepository;
		public ExistsLanguageByIdHandler(ILanguageRepository languageRepository)
		{
			this.languageRepository = languageRepository;
		}
		public async Task<bool> Handle(ExistsLanguageByIdQuery request, CancellationToken cancellationToken)
		{
			return await languageRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
