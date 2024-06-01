using Microsoft.EntityFrameworkCore;
using LanguageCenter.Data;
using LanguageCenter.Repositories.Interfaces;
using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Implementations
{
	public class PersonRepository : IPersonRepository
	{
		Context context;
		public PersonRepository(Context context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<PersonEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Persons.ToListAsync(cancellationToken);
		}

		public async Task<PersonEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Persons.FirstOrDefaultAsync(person => person.Id == id, cancellationToken);
		}

		public async Task<PersonEntity> GetByLoginAsync(string login, CancellationToken cancellationToken)
		{
			return await context.Persons.FirstOrDefaultAsync(person => person.Login.Equals(login), cancellationToken);
		}

		public async Task<PersonEntity> InsertAsync(PersonEntity person, CancellationToken cancellationToken)
		{
			await context.Persons.AddAsync(person, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return person;
		}

		public async Task<PersonEntity> UpdateAsync(PersonEntity person, CancellationToken cancellationToken)
		{
			context.Persons.Update(person);
			await context.SaveChangesAsync(cancellationToken);
			return person;
		}

		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			PersonEntity person = await GetByIdAsync(id, cancellationToken);
			if (person == null) return false;
			context.Persons.Remove(person);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Persons.AnyAsync(person => person.Id == id, cancellationToken);
		}

		public async Task<bool> ExistsByLoginAsync(string login, CancellationToken cancellationToken)
		{
			return await context.Persons.AnyAsync(person => person.Login.Equals(login), cancellationToken);
		}
	}
}
