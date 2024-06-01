using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Queries.GetLevelById
{
	public class GetLevelByIdHandler : IRequestHandler<GetLevelByIdQuery, LevelEntity>
	{
		private readonly ILevelRepository levelRepository;
		public GetLevelByIdHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<LevelEntity> Handle(GetLevelByIdQuery request, CancellationToken cancellationToken)
		{
			return await levelRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
