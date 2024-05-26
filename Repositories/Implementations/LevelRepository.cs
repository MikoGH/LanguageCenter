using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;

namespace LanguageCenter.Repositories.Implementations
{
    public class LevelRepository : ILevelRepository
    {
        Context context;
        public LevelRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<LevelEntity> GetAll()
        {
            return context.Levels.ToList();
        }

        public LevelEntity GetById(int id)
        {
            return context.Levels.Where(level => level.Id == id).FirstOrDefault();
        }

        public void Insert(LevelEntity level)
        {
            context.Levels.Add(level);
            context.SaveChanges();
        }

        public void Update(LevelEntity level)
        {
            context.Levels.Update(level);
            context.SaveChanges();
        }

        public void Delete(LevelEntity level)
        {
            context.Levels.Remove(level);
            context.SaveChanges();
        }
        public bool ExistById(int id)
        {
            return context.Levels.Any(level => level.Id == id);
        }
    }
}
