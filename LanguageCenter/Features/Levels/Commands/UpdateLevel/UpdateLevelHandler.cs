using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Levels.Commands.UpdateLevel
{
	public class UpdateLevelHandler : IRequestHandler<UpdateLevelCommand, LevelEntity>
	{
		private readonly ILevelRepository levelRepository;
		public UpdateLevelHandler(ILevelRepository levelRepository)
		{
			this.levelRepository = levelRepository;
		}

		public async Task<LevelEntity> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
		{
			return await levelRepository.UpdateAsync(request.level, cancellationToken);
		}
	}
}
