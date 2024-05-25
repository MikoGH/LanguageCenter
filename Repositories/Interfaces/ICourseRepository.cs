using LanguageCenter.Models;

namespace LanguageCenter.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<CourseEntity> GetAll();
        public CourseEntity GetById(int id);
        public void Insert(CourseEntity course);
        public void Update(CourseEntity course);
        public void Delete(CourseEntity course);
    }
}
