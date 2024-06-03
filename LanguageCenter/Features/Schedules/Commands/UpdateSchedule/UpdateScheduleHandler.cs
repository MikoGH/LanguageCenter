using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.UpdateSchedule
{
	public class UpdateScheduleHandler : IRequestHandler<UpdateScheduleCommand, ScheduleEntity>
	{
		private readonly IScheduleRepository scheduleRepository;
		public UpdateScheduleHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<ScheduleEntity> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.UpdateAsync(request.schedule, cancellationToken);
		}
	}
}
