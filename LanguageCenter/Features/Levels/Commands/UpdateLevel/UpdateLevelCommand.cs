using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Levels.Commands.UpdateLevel
{
	public record UpdateLevelCommand(LevelEntity level) : IRequest<LevelEntity>;
}
