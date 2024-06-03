using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.GetScheduleById
{
	public record GetScheduleByIdQuery(int id) : IRequest<ScheduleEntity>;
}
