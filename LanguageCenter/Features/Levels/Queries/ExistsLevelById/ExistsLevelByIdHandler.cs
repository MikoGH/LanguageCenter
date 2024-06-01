using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Queries.ExistsLevelById
{
	public class ExistsLevelByIdHandler : IRequestHandler<ExistsLevelByIdQuery, bool>
	{
		private readonly ILevelRepository levelRepository;
		public ExistsLevelByIdHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<bool> Handle(ExistsLevelByIdQuery request, CancellationToken cancellationToken)
		{
			return await levelRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
