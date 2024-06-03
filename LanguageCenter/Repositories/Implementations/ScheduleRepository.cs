using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class ScheduleRepository : IScheduleRepository
	{
		private readonly Context context;
		public ScheduleRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<ScheduleEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Schedules.ToListAsync(cancellationToken);
		}

		public async Task<ScheduleEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Schedules.FirstOrDefaultAsync(schedule => schedule.Id == id, cancellationToken);
		}

		public async Task<ScheduleEntity> InsertAsync(ScheduleEntity schedule, CancellationToken cancellationToken)
		{
			await context.Schedules.AddAsync(schedule, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return schedule;
		}

		public async Task<ScheduleEntity> UpdateAsync(ScheduleEntity schedule, CancellationToken cancellationToken)
		{
			context.Schedules.Update(schedule);
			await context.SaveChangesAsync(cancellationToken);
			return schedule;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			ScheduleEntity schedule = await GetByIdAsync(id, cancellationToken);
			if (schedule == null) return false;
			context.Schedules.Remove(schedule);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Schedules.AnyAsync(schedule => schedule.Id == id, cancellationToken);
		}
	}
}
