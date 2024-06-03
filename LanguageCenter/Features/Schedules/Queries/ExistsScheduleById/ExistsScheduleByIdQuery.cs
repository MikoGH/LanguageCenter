using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.ExistsScheduleById
{
	public record ExistsScheduleByIdQuery(int id) : IRequest<bool>;
}
