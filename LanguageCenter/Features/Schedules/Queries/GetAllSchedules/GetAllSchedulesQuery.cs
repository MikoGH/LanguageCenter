using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.GetAllSchedules
{
	public record GetAllSchedulesQuery() : IRequest<IEnumerable<ScheduleEntity>>;
}
