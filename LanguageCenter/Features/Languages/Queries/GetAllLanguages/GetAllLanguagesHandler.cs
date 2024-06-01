using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Queries.GetAllLanguages
{
	public class GetAllLanguagesHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<LanguageEntity>>
	{
		private readonly ILanguageRepository languageRepository;
		public GetAllLanguagesHandler(ILanguageRepository languageRepository)
		{
			this.languageRepository = languageRepository;
		}
		public async Task<IEnumerable<LanguageEntity>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
		{
			return await languageRepository.GetAllAsync(cancellationToken);
		}
	}
}
