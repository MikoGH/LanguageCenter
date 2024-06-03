using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.GetAllSchedules
{
	public class GetAllSchedulesHandler : IRequestHandler<GetAllSchedulesQuery, IEnumerable<ScheduleEntity>>
	{
		private readonly IScheduleRepository scheduleRepository;
		public GetAllSchedulesHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<IEnumerable<ScheduleEntity>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.GetAllAsync(cancellationToken);
		}
	}
}
