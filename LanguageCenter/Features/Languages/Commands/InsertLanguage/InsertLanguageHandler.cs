using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Commands.InsertLanguage
{
	public class InsertLanguageHandler : IRequestHandler<InsertLanguageCommand, LanguageEntity>
	{
		private readonly ILanguageRepository languageRepository;
		public InsertLanguageHandler(ILanguageRepository languageRepository) 
		{ 
			this.languageRepository = languageRepository;
		}
		public async Task<LanguageEntity> Handle(InsertLanguageCommand request, CancellationToken cancellationToken)
		{
			return await languageRepository.InsertAsync(request.language, cancellationToken);
		}
	}
}
