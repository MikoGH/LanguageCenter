using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.InsertSchedule
{
	public class InsertScheduleHandler : IRequestHandler<InsertScheduleCommand, ScheduleEntity>
	{
		private readonly IScheduleRepository scheduleRepository;
		public InsertScheduleHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<ScheduleEntity> Handle(InsertScheduleCommand request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.InsertAsync(request.schedule, cancellationToken);
		}
	}
}
