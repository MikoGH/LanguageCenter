using LanguageCenter.Data;
using LanguageCenter.Models.Entity;
using LanguageCenter.Repositories.Interfaces;

namespace LanguageCenter.Repositories.Implementations
{
	public class PersonRepository : IPersonRepository
	{
		Context context;
		public PersonRepository(Context context)
		{
			this.context = context;
		}

		public IEnumerable<PersonEntity> GetAll()
		{
			return context.Persons.ToList();
		}

		public PersonEntity GetById(int id)
		{
			return context.Persons.Where(person => person.Id == id).FirstOrDefault();
		}
		
		public void Insert(PersonEntity person)
		{
			context.Persons.Add(person);
			context.SaveChanges();
		}

		public void Update(PersonEntity person)
		{
			context.Persons.Update(person);
			context.SaveChanges();
		}

		public void Delete(PersonEntity person)
		{
			context.Persons.Remove(person);
			context.SaveChanges();
		}

		public bool ExistById(int id)
		{
			return context.Persons.Any(person => person.Id == id);
		}
	}
}
