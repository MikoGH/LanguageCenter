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

		/// <summary>
		/// Получить список всех людей
		/// </summary>
		/// <returns>Список людей</returns>
		public async Task<IEnumerable<PersonEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Persons.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить человека по id
		/// </summary>
		/// <param name="id">id человека</param>
		/// <returns>Человек</returns>
		public async Task<PersonEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Persons.FirstOrDefaultAsync(person => person.Id == id, cancellationToken);
		}

		/// <summary>
		/// Получить человека по логину
		/// </summary>
		/// <param name="login">логин человека</param>
		/// <returns>Человек</returns>
		public async Task<PersonEntity> GetByLoginAsync(string login, CancellationToken cancellationToken)
		{
			return await context.Persons.FirstOrDefaultAsync(person => person.Login.Equals(login), cancellationToken);
		}

		/// <summary>
		/// Добавить нового человек
		/// </summary>
		/// <param name="person">Человек</param>
		/// <returns>Человек</returns>
		public async Task<PersonEntity> InsertAsync(PersonEntity person, CancellationToken cancellationToken)
		{
			await context.Persons.AddAsync(person, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return person;
		}

		/// <summary>
		/// Изменить человека
		/// </summary>
		/// <param name="person">Человек</param>
		/// <returns>Человек</returns>
		public async Task<PersonEntity> UpdateAsync(PersonEntity person, CancellationToken cancellationToken)
		{
			context.Persons.Update(person);
			await context.SaveChangesAsync(cancellationToken);
			return person;
		}

		/// <summary>
		/// Удалить человека по id
		/// </summary>
		/// <param name="id">id человека</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			PersonEntity person = await GetByIdAsync(id, cancellationToken);
			if (person == null) return false;
			context.Persons.Remove(person);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли человек с данным id
		/// </summary>
		/// <param name="id">id человека</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Persons.AnyAsync(person => person.Id == id, cancellationToken);
		}

		/// <summary>
		/// Проверить, существует ли человек с данным логином
		/// </summary>
		/// <param name="login">логин человека</param>
		/// <returns>true если логин существует, иначе false</returns>
		public async Task<bool> ExistsByLoginAsync(string login, CancellationToken cancellationToken)
		{
			return await context.Persons.AnyAsync(person => person.Login.Equals(login), cancellationToken);
		}
	}
}
