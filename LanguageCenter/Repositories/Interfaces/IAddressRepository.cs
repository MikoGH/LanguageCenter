using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IAddressRepository
	{
		public Task<IEnumerable<AddressEntity>> GetAllAsync(CancellationToken cancellationToken);
		public Task<AddressEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
		public Task<AddressEntity> InsertAsync(AddressEntity address, CancellationToken cancellationToken);
		public Task<AddressEntity> UpdateAsync(AddressEntity address, CancellationToken cancellationToken);
		public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
		public Task<bool> ExistsByIdAsync(int id, CancellationToken cancellationToken);
	}
}
