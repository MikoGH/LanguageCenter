using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Queries.GetAllLevels
{
	public class GetAllLevelsHandler : IRequestHandler<GetAllLevelsQuery, IEnumerable<LevelEntity>>
	{
		private readonly ILevelRepository levelRepository;
		public GetAllLevelsHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<IEnumerable<LevelEntity>> Handle(GetAllLevelsQuery request, CancellationToken cancellationToken)
		{
			return await levelRepository.GetAllAsync(cancellationToken);
		}
	}
}
