using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.DeleteScheduleById
{
	public record DeleteScheduleByIdCommand(int id) : IRequest<bool>;
}
