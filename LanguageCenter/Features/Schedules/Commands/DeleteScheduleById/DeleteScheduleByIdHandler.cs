using LanguageCenter.Repositories.Interfaces;
using MediatR;

namespace LanguageCenter.Features.Schedules.Commands.DeleteScheduleById
{
	public class DeleteScheduleByIdHandler : IRequestHandler<DeleteScheduleByIdCommand, bool>
	{
		private readonly IScheduleRepository scheduleRepository;
		public DeleteScheduleByIdHandler(IScheduleRepository scheduleRepository)
		{
			this.scheduleRepository = scheduleRepository;
		}
		public async Task<bool> Handle(DeleteScheduleByIdCommand request, CancellationToken cancellationToken)
		{
			return await scheduleRepository.DeleteByIdAsync(request.id, cancellationToken);
		}
	}
}
