using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Levels.Queries.GetAllLevels
{
	public record GetAllLevelsQuery() : IRequest<IEnumerable<LevelEntity>>;
}
