using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.GetScheduleById
{
	public class GetScheduleByIdHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleEntity>
	{
		private readonly IScheduleRepository scheduleRepository;
		public GetScheduleByIdHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<ScheduleEntity> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.GetByIdAsync(request.id, cancellationToken);
		}
	}
}
