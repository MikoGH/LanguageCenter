using LanguageCenter.Models.Entity;

namespace LanguageCenter.Repositories.Interfaces
{
    public interface ILevelRepository
    {
        public IEnumerable<LevelEntity> GetAll();
        public LevelEntity GetById(int id);
        public void Insert(LevelEntity level);
        public void Update(LevelEntity level);
        public void Delete(LevelEntity level);
		public bool ExistById(int id);
	}
}
