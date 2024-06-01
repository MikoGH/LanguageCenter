using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Courses.Queries.GetCourseById
{
	public record GetCourseByIdQuery(int id) : IRequest<CourseEntity>;
}
