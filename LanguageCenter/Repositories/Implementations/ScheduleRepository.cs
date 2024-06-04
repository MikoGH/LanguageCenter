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

		/// <summary>
		/// Получить список всех расписаний
		/// </summary>
		/// <returns>Список расписаний</returns>
		public async Task<IEnumerable<ScheduleEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Schedules.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить расписание по id
		/// </summary>
		/// <param name="id">id расписания</param>
		/// <returns>Расписание</returns>
		public async Task<ScheduleEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Schedules.FirstOrDefaultAsync(schedule => schedule.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новое расписание
		/// </summary>
		/// <param name="schedule">Расписание</param>
		/// <returns>Расписание</returns>
		public async Task<ScheduleEntity> InsertAsync(ScheduleEntity schedule, CancellationToken cancellationToken)
		{
			await context.Schedules.AddAsync(schedule, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return schedule;
		}

		/// <summary>
		/// Изменить расписание
		/// </summary>
		/// <param name="schedule">Расписание</param>
		/// <returns>Расписание</returns>
		public async Task<ScheduleEntity> UpdateAsync(ScheduleEntity schedule, CancellationToken cancellationToken)
		{
			context.Schedules.Update(schedule);
			await context.SaveChangesAsync(cancellationToken);
			return schedule;
		}

		/// <summary>
		/// Удалить расписание по id
		/// </summary>
		/// <param name="id">id расписания</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			ScheduleEntity schedule = await GetByIdAsync(id, cancellationToken);
			if (schedule == null) return false;
			context.Schedules.Remove(schedule);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли расписание с данным id
		/// </summary>
		/// <param name="id">id расписания</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Schedules.AnyAsync(schedule => schedule.Id == id, cancellationToken);
		}
	}
}
