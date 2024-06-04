using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguageCenter.Repositories.Implementations
{
	public class AddressRepository : IAddressRepository
	{
		private readonly Context context;
		public AddressRepository(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Получить список всех адресов
		/// </summary>
		/// <returns>Список адресов</returns>
		public async Task<IEnumerable<AddressEntity>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await context.Addresses.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Получить адрес по id
		/// </summary>
		/// <param name="id">id адреса</param>
		/// <returns>Адрес</returns>
		public async Task<AddressEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Addresses.FirstOrDefaultAsync(address => address.Id == id, cancellationToken);
		}

		/// <summary>
		/// Добавить новый адрес
		/// </summary>
		/// <param name="address">Адрес</param>
		/// <returns>Адрес</returns>
		public async Task<AddressEntity> InsertAsync(AddressEntity address, CancellationToken cancellationToken)
		{
			await context.Addresses.AddAsync(address, cancellationToken);
			await context.SaveChangesAsync(cancellationToken);
			return address;
		}

		/// <summary>
		/// Изменить адрес
		/// </summary>
		/// <param name="address">Адрес</param>
		/// <returns>Адрес</returns>
		public async Task<AddressEntity> UpdateAsync(AddressEntity address, CancellationToken cancellationToken)
		{
			context.Addresses.Update(address);
			await context.SaveChangesAsync(cancellationToken);
			return address;
		}

		/// <summary>
		/// Удалить адрес по id
		/// </summary>
		/// <param name="id">id адреса</param>
		/// <returns>false если id отсутствует; иначе true</returns>
		public async Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken)
		{
			AddressEntity address = await GetByIdAsync(id, cancellationToken);
			if (address == null) return false;
			context.Addresses.Remove(address);
			await context.SaveChangesAsync(cancellationToken);
			return true;
		}

		/// <summary>
		/// Проверить, существует ли адрес с данным id
		/// </summary>
		/// <param name="id">id адреса</param>
		/// <returns>true если id существует, иначе false</returns>
		public async Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken)
		{
			return await context.Addresses.AnyAsync(address => address.Id == id, cancellationToken);
		}
	}
}
