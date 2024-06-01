using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Courses.Queries.GetAllCourses
{
	public record GetAllCoursesQuery() : IRequest<IEnumerable<CourseEntity>>;
}
