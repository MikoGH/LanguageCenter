using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class ClassroomRepository : IClassroomRepository
	{
		private readonly Context context;
		public ClassroomRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<ClassroomEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Classrooms.ToListAsync(cancellationToken);
		}

		public async Task<ClassroomEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Classrooms.FirstOrDefaultAsync(classroom => classroom.Id == id, cancellationToken);
		}

		public async Task<ClassroomEntity> InsertAsync(ClassroomEntity classroom, CancellationToken cancellationToken)
		{
			await context.Classrooms.AddAsync(classroom, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return classroom;
		}

		public async Task<ClassroomEntity> UpdateAsync(ClassroomEntity classroom, CancellationToken cancellationToken)
		{
			context.Classrooms.Update(classroom);
			await context.SaveChangesAsync(cancellationToken);
			return classroom;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			ClassroomEntity classroom = await GetByIdAsync(id, cancellationToken);
			if (classroom == null) return false;
			context.Classrooms.Remove(classroom);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Classrooms.AnyAsync(classroom => classroom.Id == id, cancellationToken);
		}
	}
}
