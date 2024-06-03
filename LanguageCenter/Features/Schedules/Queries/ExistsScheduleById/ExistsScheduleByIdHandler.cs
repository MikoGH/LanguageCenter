using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Queries.ExistsScheduleById
{
	public class ExistsScheduleByIdHandler : IRequestHandler<ExistsScheduleByIdQuery, bool>
	{
		private readonly IScheduleRepository scheduleRepository;
		public ExistsScheduleByIdHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<bool> Handle(ExistsScheduleByIdQuery request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.ExistsByIdAsync(request.id, cancellationToken);
		}
	}
}
