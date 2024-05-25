using LanguageCenter.Data;
using LanguageCenter.Models;
using LanguageCenter.Repositories.Interfaces;
using System.Reflection.Emit;

namespace LanguageCenter.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        Context context;
        public CourseRepository(Context _context)
        {
            context = _context;
        }

        public IEnumerable<CourseEntity> GetAll()
        {
            return context.Courses.ToList();
        }

        public CourseEntity GetById(int id)
        {
            return context.Courses.Where(course => course.Id == id).FirstOrDefault();
        }

        public void Insert(CourseEntity course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void Update(CourseEntity course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }

        public void Delete(CourseEntity course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }
    }
}
