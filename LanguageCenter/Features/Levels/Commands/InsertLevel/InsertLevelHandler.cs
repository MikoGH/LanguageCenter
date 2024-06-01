using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Commands.InsertLevel
{
	public class InsertLevelHandler : IRequestHandler<InsertLevelCommand, LevelEntity>
	{
		private readonly ILevelRepository levelRepository;
		public InsertLevelHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<LevelEntity> Handle(InsertLevelCommand request, CancellationToken cancellationToken)
		{
			return await levelRepository.InsertAsync(request.level, cancellationToken);
		}
	}
}
