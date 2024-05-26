using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;

namespace LanguageCenter.Repositories.Implementations
{
    public class LanguageRepository : ILanguageRepository
    {
        Context context;
        public LanguageRepository(Context context)
		{
			this.context = context;
		}

        public IEnumerable<LanguageEntity> GetAll()
        {
            return context.Languages.ToList();
        }

        public LanguageEntity GetById(int id)
        {
            return context.Languages.Where(language => language.Id == id).FirstOrDefault();
        }

        public void Insert(LanguageEntity language)
        {
            context.Languages.Add(language);
            context.SaveChanges();
        }

        public void Update(LanguageEntity language)
        {
            context.Languages.Update(language);
            context.SaveChanges();
        }

        public void Delete(LanguageEntity language)
        {
            context.Languages.Remove(language);
            context.SaveChanges();
        }
        public bool ExistById(int id) 
        { 
            return context.Languages.Any(language => language.Id == id);
        }
    }
}
