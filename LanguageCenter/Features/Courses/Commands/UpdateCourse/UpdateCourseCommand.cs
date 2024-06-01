using LanguageCenter.Models;
using MediatR;

namespace LanguageCenter.Features.Courses.Commands.UpdateCourse
{
	public record UpdateCourseCommand(CourseEntity course) : IRequest<CourseEntity>;
}
