using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.InsertSchedule
{
	public record InsertScheduleCommand(ScheduleEntity schedule) : IRequest<ScheduleEntity>;
}
