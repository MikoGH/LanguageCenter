using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Commands.UpdateLanguage
{
	public class UpdateLanguageHandler : IRequestHandler<UpdateLanguageCommand, LanguageEntity>
	{
		private readonly ILanguageRepository languageRepository;
		public UpdateLanguageHandler(ILanguageRepository languageRepository)
		{
			this.languageRepository = languageRepository;
		}

		public async Task<LanguageEntity> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
		{
			return await languageRepository.UpdateAsync(request.language, cancellationToken);
		}
	}
}
