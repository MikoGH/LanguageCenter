using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Languages.Commands.DeleteLanguageById
{
	public class DeleteLanguageByIdHandler : IRequestHandler<DeleteLanguageByIdCommand, bool>
	{
		private readonly ILanguageRepository languageRepository;
		public DeleteLanguageByIdHandler(ILanguageRepository languageRepository)
		{
			this.languageRepository = languageRepository;
		}

		public async Task<bool> Handle(DeleteLanguageByIdCommand request, CancellationToken cancellationToken)
		{
			return await languageRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
