using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Levels.Commands.InsertLevel
{
	public record InsertLevelCommand(LevelEntity level) : IRequest<LevelEntity>;
}
