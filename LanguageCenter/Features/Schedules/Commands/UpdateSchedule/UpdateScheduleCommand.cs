using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.UpdateSchedule
{
	public record UpdateScheduleCommand(ScheduleEntity schedule) : IRequest<ScheduleEntity>;
}
