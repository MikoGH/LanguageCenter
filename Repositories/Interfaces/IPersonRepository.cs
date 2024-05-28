using LanguageCenter.Models.Entity;

namespace LanguageCenter.Repositories.Interfaces
{
	public interface IPersonRepository
	{
		public IEnumerable<PersonEntity> GetAll();
		public PersonEntity GetById(int id);
		public PersonEntity GetByLogin(string login);
		public void Insert(PersonEntity person);
		public void Update(PersonEntity person);
		public void Delete(PersonEntity person);
		public bool ExistById(int id);
		public bool ExistByLogin(string login);
	}
}
