using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Queries.GetLanguageById
{
	public class GetLanguageByIdHandler : IRequestHandler<GetLanguageByIdQuery, LanguageEntity>
	{
		private readonly ILanguageRepository languageRepository;
		public GetLanguageByIdHandler(ILanguageRepository languageRepository)
		{
			this.languageRepository = languageRepository;
		}
		public async Task<LanguageEntity> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
		{
			return await languageRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
