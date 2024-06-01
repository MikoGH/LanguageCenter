using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Levels.Queries.GetLevelById
{
	public record GetLevelByIdQuery(int id) : IRequest<LevelEntity>;
}
