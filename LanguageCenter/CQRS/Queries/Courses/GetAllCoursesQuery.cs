using LanguageCenter.Models.Entity;
using MediatR;

namespace LanguageCenter.CQRS.Queries.Courses
{
    public record GetAllCoursesQuery() : IRequest<IEnumerable<CourseEntity>>;
}
