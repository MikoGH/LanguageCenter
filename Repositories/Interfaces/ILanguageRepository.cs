using LanguageCenter.Models.Entity;

namespace LanguageCenter.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        public IEnumerable<LanguageEntity> GetAll();
        public LanguageEntity GetById(int id);
        public void Insert(LanguageEntity language);
        public void Update(LanguageEntity language);
        public void Delete(LanguageEntity language);
		public bool ExistById(int id);
	}
}
